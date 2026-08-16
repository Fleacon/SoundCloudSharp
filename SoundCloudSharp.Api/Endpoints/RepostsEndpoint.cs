using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Request.Paging;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class RepostsEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<Paging<Track>> GetRepostedTracksAsync(GetRepostedTrackRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.MeRepostTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Playlist>> GetRepostedPlaylistsAsync(GetRepostedPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.MeRepostPlaylists(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Track>> GetUserRepostedTracksAsync(string userUrn, GetUserRepostedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserRepostedTracks(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Playlist>> GetUserRepostedPlaylistsAsync(string userUrn, GetUserRepostedPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserRepostedPlaylists(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<bool> RepostTrackAsync(string trackUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PostAsync(SoundCloudUrls.RepostTracks(trackUrn), cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    [Obsolete("Marked as Deprecated by SoundCloud endpoint")]
    public async Task<bool> RemoveRepostTrackAsync(string trackUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.DeleteAsync(SoundCloudUrls.RepostTracks(trackUrn), cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> RepostPlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PostAsync(SoundCloudUrls.RepostPlaylists(playlistUrn), cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> RemoveRepostPlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.DeleteAsync(SoundCloudUrls.RepostPlaylists(playlistUrn), cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }
}