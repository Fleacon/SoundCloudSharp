using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Endpoints;

public class MiscellaneousEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<FoundResponse> ResolveAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(uri, "url");
        return await Connector.GetAsync<FoundResponse>(SoundCloudUrls.Resolve(), query, cancellationToken).ConfigureAwait(false);
    }
}