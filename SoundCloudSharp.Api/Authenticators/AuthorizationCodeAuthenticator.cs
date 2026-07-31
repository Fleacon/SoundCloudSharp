using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Authenticators;

public class AuthorizationCodeAuthenticator(string clientId, string clientSecret, OAuthToken token)
    : IAuthenticator
{
    public string ClientId { get; init; } = clientId;
    public string ClientSecret { get; init; } = clientSecret;
    public OAuthToken CurrentToken { get; private set; } = token;

    public async Task Apply(Request request, ApiConnector connector, CancellationToken cancellationToken = default)
    {
        if (CurrentToken.IsExpired)
        {
            var content = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["client_id"] = ClientId,
                ["client_secret"] = ClientSecret,
                ["refresh_token"] = CurrentToken.RefreshToken
            };
            var form = new FormUrlEncodedContent(content);
        
            CurrentToken = await connector.AuthPostAsync<OAuthToken>(SoundCloudUrls.OAuthTokenUri, form, cancellationToken: cancellationToken);
        }

        request.Headers["Authorization"] = $"OAuth {CurrentToken.AccessToken}";
    }
}