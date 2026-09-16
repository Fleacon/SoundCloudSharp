using System.Web;
using SoundCloudSharp.Api.Exceptions;
using SoundCloudSharp.Api.Models.Auth;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Authenticators;

/// <summary>
/// Implements the authorization code flow with PKCE for authenticating a user
/// against SoundCloud's OAuth2.1 endpoints.
/// </summary>
/// <remarks>
/// This class only builds and validates the pieces of the flow (the
/// authorization URL, the state/PKCE values, and the token request). It does
/// not perform any network calls itself. The consumer is responsible for:
/// <list type="number">
/// <item>Redirecting the user to the URI returned by <see cref="CreateRequest"/>,
/// and persisting its <c>CodeVerifier</c> and <c>State</c> values until the callback is received.</item>
/// <item>Building a token request from the callback via
/// <see cref="CreateTokenRequest"/>, and exchanging it for an
/// <c>OAuthToken</c> using <see cref="SoundCloudSharp.Api.Endpoints.OAuthClient">OAuthClient</see></item>
/// </list>
/// </remarks>
public static class AuthorizationCodeFlow
{
    /// <summary>
    /// Builds the URI the user should be redirected to in order to authorize
    /// the application, along with the PKCE code verifier and CSRF state
    /// value generated for this request.
    /// </summary>
    /// <remarks>
    /// The returned <c>CodeVerifier</c> and <c>State</c> must be persisted by
    /// the caller (e.g. in short-lived, HTTP-only cookies tied to the user's
    /// session) and supplied again to <see cref="CreateTokenRequest"/> once
    /// the authorization callback is received. Losing either value before
    /// the callback arrives will make the flow impossible to complete.
    /// </remarks>
    /// <param name="clientId">The client ID from your SoundCloud application registration.</param>
    /// <param name="redirectUri">
    /// The redirect URI configured for your application. SoundCloud will
    /// redirect the user back to this URI once they authorize (or deny) access.
    /// </param>
    /// <param name="mobilePopUp">
    /// If <see langword="true"/>, requests SoundCloud's popup-style
    /// authorization display, intended for mobile/embedded contexts, instead
    /// of the default full-page display.
    /// </param>
    /// <returns>
    /// The authorization URI to redirect the user to, together with the PKCE
    /// code verifier and state value that must be persisted for the
    /// remainder of the flow.
    /// </returns>
    public static AuthorizationCodeUri CreateRequest(string clientId, Uri redirectUri, bool mobilePopUp = false)
    {
        var state = Guid.NewGuid().ToString();
        var codeVerifier = PKCEUtil.GenerateCodeVerifier();
        var codeChallenge = PKCEUtil.GenerateCodeChallenge(codeVerifier);

        var baseUri = SoundCloudUrls.SecureUri;
        var path = SoundCloudUrls.Authorization();
        var builder = new UriBuilder(new Uri(baseUri, path));
        var query = HttpUtility.ParseQueryString(string.Empty);

        query["client_id"] = clientId;
        query["redirect_uri"] = redirectUri.AbsoluteUri;
        query["response_type"] = "code";
        query["code_challenge"] = codeChallenge;
        query["code_challenge_method"] = "S256";
        query["state"] = state;
        if (mobilePopUp) query["display"] = "popup";
        
        builder.Query = query.ToString();
        
        return new (builder.Uri, codeVerifier, state);
    }

    /// <summary>
    /// Validates the authorization callback and builds a request that can be
    /// exchanged for an access token.
    /// </summary>
    /// <remarks>
    /// This validates the callback's <c>state</c> value against
    /// <paramref name="expectedState"/> as a CSRF protection. The value
    /// originally returned by <see cref="CreateRequest"/> for this
    /// authorization attempt. A mismatch, or a missing code/state, causes
    /// this method to throw rather than return a usable request.
    /// </remarks>
    /// <param name="clientSecrets">The client ID and secret from your SoundCloud application registration.</param>
    /// <param name="callbackUri">
    /// The full URI SoundCloud redirected the user back to, including its
    /// query string (containing <c>code</c> and <c>state</c>).
    /// </param>
    /// <param name="redirectUri">
    /// The same redirect URI originally passed to <see cref="CreateRequest"/>.
    /// </param>
    /// <param name="codeVerifier">
    /// The PKCE code verifier returned by <see cref="CreateRequest"/> for this
    /// authorization attempt.
    /// </param>
    /// <param name="expectedState">
    /// The state value returned by <see cref="CreateRequest"/> for this
    /// authorization attempt, to validate against the value SoundCloud
    /// echoes back in <paramref name="callbackUri"/>.
    /// </param>
    /// <returns>A request that can be exchanged for an <c>OAuthToken</c>.</returns>
    /// <exception cref="OAuthCallbackException">
    /// <paramref name="callbackUri"/> does not contain an authorization code,
    /// or <paramref name="codeVerifier"/> is missing or empty.
    /// </exception>
    /// <exception cref="OAuthStateMismatchException">
    /// <paramref name="callbackUri"/> does not contain a state value, or its
    /// value does not match <paramref name="expectedState"/>, indicating a
    /// possible CSRF attempt or a stale/reused callback.
    /// </exception>
    public static AuthorizationCodeTokenRequest CreateTokenRequest(ClientSecrets clientSecrets, Uri callbackUri, Uri redirectUri, string codeVerifier, string expectedState)
    {
        var query = HttpUtility.ParseQueryString(callbackUri.Query);
        
        var code = query["code"];
        var returnedState = query["state"];

        if (string.IsNullOrEmpty(code))
            throw new OAuthCallbackException("The authorization callback did not contain a code.");
        
        if (string.IsNullOrEmpty(returnedState))
            throw new OAuthStateMismatchException("The authorization callback did not contain a state.");
        
        if (returnedState != expectedState)
            throw new OAuthStateMismatchException("The authorization callback contained an invalid state.");
        
        if (string.IsNullOrWhiteSpace(codeVerifier))
            throw new OAuthCallbackException("The PKCE code verifier is missing.");

        return new AuthorizationCodeTokenRequest(clientSecrets, redirectUri, code, codeVerifier);
    }
}