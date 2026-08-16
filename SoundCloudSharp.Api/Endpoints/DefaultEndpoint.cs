using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Endpoints;

public class DefaultEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task SignOutAsync(CancellationToken cancellationToken = default)
    {
        await Connector.PostAsync(SoundCloudUrls.SignOut(), cancellationToken).ConfigureAwait(false);
    }
}