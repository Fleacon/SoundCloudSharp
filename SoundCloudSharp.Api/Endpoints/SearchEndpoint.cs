using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Endpoints;

public class SearchEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<Paging<Track>> SearchTracksAsync(SearchTracksRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.Tracks(), query);
        return await Connector.GetAsync<Paging<Track>>(uri, cancellationToken);
    }

    public async Task<Paging<Playlist>> SearchPlaylistsAsync(SearchPlaylistsRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.Playlists(), query);
        return await Connector.GetAsync<Paging<Playlist>>(uri, cancellationToken);
    }

    public async Task<Paging<FullUser>> SearchUsersAsync(SearchUsersRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.Users(), query);
        return await Connector.GetAsync<Paging<FullUser>>(uri, cancellationToken);
    }
}