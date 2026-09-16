using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Auth;

namespace SoundCloudSharp.Api.Authenticators;

/// <summary>
/// Implements an authenticator that manages and automatically refreshes 
/// OAuth tokens for API requests against SoundCloud's endpoints.
/// </summary>
/// <remarks>
/// This authenticator inspects the outgoing request's token expiration status.
/// If the token is expired, it transparently performs a token refresh request 
/// using the stored refresh token before attaching the valid access token 
/// to the request's Authorization header.
/// </remarks>
/// <param name="clientSecrets">The client ID and secret from your SoundCloud application registration.</param>
/// <param name="token">The initial OAuth token, which must include a valid refresh token.</param>
public class OAuthTokenAuthenticator(ClientSecrets clientSecrets, OAuthToken token)
    : IAuthenticator
{
    /// <summary>
    /// The client credentials.
    /// </summary>
    public ClientSecrets ClientSecrets { get; init; } = clientSecrets;
    
    /// <summary>
    /// Current OAuth token used for authorization, which is updated automatically 
    /// when a token refresh occurs.
    /// </summary>
    public OAuthToken CurrentToken { get; private set; } = token;
    
    public async Task Apply(Request request, ApiConnector connector, CancellationToken cancellationToken = default)
    {
        if (CurrentToken.IsExpired)
        {
            var content = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["client_id"] = ClientSecrets.ClientId,
                ["client_secret"] = ClientSecrets.ClientSecret,
                ["refresh_token"] = CurrentToken.RefreshToken
            };
            var form = new FormUrlEncodedContent(content);
        
            CurrentToken = await connector.PostAsync<OAuthToken>(SoundCloudUrls.OAuthToken(), form, baseUri: SoundCloudUrls.Authorization(), cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        request.Headers["Authorization"] = $"OAuth {CurrentToken.AccessToken}";
    }
}