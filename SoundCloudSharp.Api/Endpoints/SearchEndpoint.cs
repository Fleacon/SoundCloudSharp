using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Endpoints;

public class SearchEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<Paging<Track>> SearchTracksAsync(SearchTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.Tracks(), query, cancellationToken);
    }

    public async Task<Paging<Playlist>> SearchPlaylistsAsync(SearchPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.Playlists(), query, cancellationToken);
    }

    public async Task<Paging<FullUser>> SearchUsersAsync(SearchUsersRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser>>(SoundCloudUrls.Users(), query, cancellationToken);
    }
}