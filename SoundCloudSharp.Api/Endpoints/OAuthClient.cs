using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Auth;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class OAuthClient : ApiEndpoint
{
    public OAuthClient() : base(new(SoundCloudConfig.CreateUnauthorized())) { }

    public OAuthClient(SoundCloudConfig config) : base (new (config)) { }

    public OAuthClient(ApiConnector connector) : base(connector) { }
    
    public async Task<OAuthToken> RequestTokenAsync(AuthorizationCodeTokenRequest request, CancellationToken cancellationToken = default)
    {
        var content = new Dictionary<string, string>
        {
            ["grant_type"] = "authorization_code",
            ["client_id"] = request.ClientSecrets.ClientId,
            ["client_secret"] = request.ClientSecrets.ClientSecret,
            ["redirect_uri"] = request.AuthorizationUri.AbsoluteUri,
            ["code_verifier"] = request.CodeVerifier,
            ["code"] = request.Code
        };
        var form = new FormUrlEncodedContent(content);
        return await Connector.AuthPostAsync<OAuthToken>(SoundCloudUrls.OAuthTokenUri, form, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<OAuthToken> RequestTokenAsync(ClientSecrets secrets,
        CancellationToken cancellationToken = default)
    {
        var credentials = $"{secrets.ClientId}:{secrets.ClientSecret}";
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
        
        return await Connector.AuthPostAsync<OAuthToken>(SoundCloudUrls.OAuthTokenUri, form, headers: headers, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<OAuthToken> RefreshTokenAsync(ClientSecrets secrets, string refreshToken,
        CancellationToken cancellationToken = default)
    {
        var content = new Dictionary<string, string>
        {
            ["grant_type"] = "refresh_token",
            ["client_id"] = secrets.ClientId,
            ["client_secret"] = secrets.ClientSecret,
            ["refresh_token"] = refreshToken
        };
        var form = new FormUrlEncodedContent(content);
        
        return await Connector.AuthPostAsync<OAuthToken>(SoundCloudUrls.OAuthTokenUri, form, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}