using System.Web;
using SoundCloudSharp.Api.Exceptions;
using SoundCloudSharp.Api.Models.Auth;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Authenticators;

public static class AuthorizationCodeFlow
{
    public static AuthorizationCodeUri CreateRequest(string clientId, Uri redirectUri, bool mobilePopUp = false)
    {
        var state = Guid.NewGuid().ToString();
        var codeVerifier = PKCEUtil.GenerateCodeVerifier();
        var codeChallenge = PKCEUtil.GenerateCodeChallenge(codeVerifier);
        
        var builder = new UriBuilder(SoundCloudUrls.AuthorizationUri);
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

    public static AuthorizationCodeTokenRequest CreateTokenRequest(ClientSecrets clientSecrets, Uri callbackUri, Uri redirectUri, string codeVerifier, string expectedState)
    {
        var query = HttpUtility.ParseQueryString(callbackUri.Query);
        
        var code = query["code"];
        var returnedState = query["state"];

        if (string.IsNullOrEmpty(code))
            throw new OAuthCallbackException("The authorization callback did not contain a code.");
        
        if (string.IsNullOrEmpty(returnedState))
            throw new OAuthStateMismatchException("The authorization callback did not contain a state.");
        
        Console.WriteLine($"expectedState : {expectedState}\n returnedState : {returnedState}");
        
        if (returnedState != expectedState)
            throw new OAuthStateMismatchException("The authorization callback contained an invalid state.");
        
        if (string.IsNullOrWhiteSpace(codeVerifier))
            throw new OAuthCallbackException("The PKCE code verifier is missing.");

        return new AuthorizationCodeTokenRequest(clientSecrets, redirectUri, code, codeVerifier);
    }
}