using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.Exceptions;

namespace SoundCloudSharp.Api.Endpoints;

/// <summary>
/// Miscellaneous Endpoints.
/// </summary>
public class MiscellaneousEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Resolves soundcloud.com and on.soundcloud.com URLs to Resource URLs to use With the API.
    /// 
    /// Corresponds to '<c>GET /resolve</c>'
    /// </summary>
    /// <param name="url">SoundCloud URL that will be resolved</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of </returns>
    /// <exception cref="ApiNotFoundException">The <paramref name="url"/> doesn't resolve to a valid SoundCloud URL</exception>
    public async Task<FoundResponse> ResolveAsync(Uri url, CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(url, "url");
        return await Connector.GetAsync<FoundResponse>(SoundCloudUrls.Resolve(), query, cancellationToken).ConfigureAwait(false);
    }
}