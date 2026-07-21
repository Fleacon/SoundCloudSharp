using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Endpoints;

public class MiscellaneousEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<FoundResponse> Resolve(Uri uri, CancellationToken cancellationToken = default)
    {
        var query = QueryStringBuilder.BuildScalar("url", uri);
        return await Connector.GetAsync<FoundResponse>(SoundCloudUrls.Resolve(), query, cancellationToken);
    }
}