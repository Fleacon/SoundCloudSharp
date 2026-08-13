using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Auth;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Authenticators;

public class ClientCredentialsAuthenticator(ClientSecrets clientSecrets, OAuthToken token) : IAuthenticator
{
    public ClientSecrets ClientSecrets { get; init; } = clientSecrets;
    public OAuthToken CurrentToken { get; private set; } = token;
    
    public async Task Apply(Request request, ApiConnector connector, CancellationToken cancellationToken = default)
    {
        if (CurrentToken.IsExpired)
        {
            var credentials = $"{ClientSecrets.ClientId}:{ClientSecrets.ClientSecret}";
            var credBase64 = Base64Util.Encode(credentials);
            var headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Basic {credBase64}"
            };
        
            var content = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            };
            var form = new FormUrlEncodedContent(content);
        
            CurrentToken = await connector.AuthPostAsync<OAuthToken>(SoundCloudUrls.OAuthTokenUri, form, headers: headers, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        
        request.Headers["Authorization"] = $"OAuth {CurrentToken.AccessToken}";
    }
}