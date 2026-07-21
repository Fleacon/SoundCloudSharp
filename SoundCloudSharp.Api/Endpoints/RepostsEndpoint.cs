using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Request.Paging;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class RepostsEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<Paging<Track>> GetRepostedTracks(GetRepostedTrackRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.MeRepostTracks(), query, cancellationToken);
    }

    public async Task<Paging<Playlist>> GetRepostedPlaylists(GetRepostedPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.MeRepostPlaylists(), query, cancellationToken);
    }

    public async Task<Paging<Track>> GetUserRepostedTracks(string userUrn, GetUserRepostedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserRepostedTracks(userUrn), query, cancellationToken);
    }

    public async Task<Paging<Playlist>> GetUserRepostedPlaylists(string userUrn, GetUserRepostedPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserRepostedPlaylists(userUrn), query, cancellationToken);
    }

    public async Task<bool> RepostTrack(string trackUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PostAsync(SoundCloudUrls.RepostTracks(trackUrn), cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    [Obsolete("Marked as Deprecated by SoundCloud endpoint")]
    public async Task<bool> RemoveRepostTrack(string trackUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.DeleteAsync(SoundCloudUrls.RepostTracks(trackUrn), cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> RepostPlaylist(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PostAsync(SoundCloudUrls.RepostPlaylists(playlistUrn), cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> RemoveRepostPlaylist(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.DeleteAsync(SoundCloudUrls.RepostPlaylists(playlistUrn), cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }
}