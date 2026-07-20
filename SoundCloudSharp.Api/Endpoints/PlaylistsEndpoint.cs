using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class PlaylistsEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<Playlist> CreatePlaylist(CreateUpdatePlaylistRequest body, CancellationToken cancellationToken = default)
    {
        var uri = SoundCloudUrls.Playlists();
        return await Connector.PostAsync<Playlist>(uri, body, cancellationToken);
    }

    public async Task<Playlist> GetPlaylistAsync(string playlistUrn, GetPlaylistRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Playlist>(SoundCloudUrls.Playlist(playlistUrn), query, cancellationToken);
    }

    public async Task<Playlist> UpdatePlaylistAsync(string playlistUrn, CreateUpdatePlaylistRequest body, CancellationToken cancellationToken = default)
    {
        var uri = SoundCloudUrls.Playlist(playlistUrn);
        return await Connector.PutAsync<Playlist>(uri, body, cancellationToken);
    }

    public async Task<bool> DeletePlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var uri = SoundCloudUrls.Playlist(playlistUrn);
        var response = await Connector.DeleteAsync(uri, cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<Paging<Track>> GetPlaylistTracksAsync(string playlistUrn, GetPlaylistRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.PlaylistTracks(playlistUrn), query, cancellationToken);
    }

    public async Task<Paging<FullUser>> GetPlaylistReposters(string playlistUrn, int? limit = 50,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit);
        return await Connector.GetAsync<Paging<FullUser>>(SoundCloudUrls.PlaylistReposters(playlistUrn), query, cancellationToken);
    }
}
    
    