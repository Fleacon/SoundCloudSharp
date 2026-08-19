using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Auth;

namespace SoundCloudSharp.Api.Authenticators;

public class OAuthTokenAuthenticator(ClientSecrets clientSecrets, OAuthToken token)
    : IAuthenticator
{
    public ClientSecrets ClientSecrets { get; init; } = clientSecrets;
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
        
            CurrentToken = await connector.AuthPostAsync<OAuthToken>(SoundCloudUrls.OAuthTokenUri, form, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        request.Headers["Authorization"] = $"OAuth {CurrentToken.AccessToken}";
    }
}