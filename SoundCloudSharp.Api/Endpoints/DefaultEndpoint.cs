using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Endpoints;

public class DefaultEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task SignOutAsync(string accessToken, CancellationToken cancellationToken = default)
    {
        var body = new { access_token = accessToken };
        await Connector.AuthPostAsync<object>(SoundCloudUrls.SignOut, body, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}