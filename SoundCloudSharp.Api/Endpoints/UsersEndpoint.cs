using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Endpoints;

public class UsersEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<FullUser> GetUserAsync(string userUrn, CancellationToken cancellationToken = default)
    {
        return await Connector.GetAsync<FullUser>(SoundCloudUrls.User(userUrn), cancellationToken).ConfigureAwait(false); 
    }

    public async Task<Paging<FullUser?>> GetRelatedArtistsAsync(string userUrn,
        GetUserRelatedArtistsRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.UserRelated(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<FullUser?>> GetFollowersAsync(string userUrn, int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit, "limit");
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.UserFollowers(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<FullUser?>> GetFollowingsAsync(string userUrn, int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit, "limit");
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.UserFollowings(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Playlist>> GetPlaylistsAsync(string userUrn, GetUserPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserPlaylists(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Track>> GetTracksAsync(string userUrn, GetUserTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserTracks(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<WebProfiles> GetWebProfileAsync(string userUrn, int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit, "limit");
        return await Connector.GetAsync<WebProfiles>(SoundCloudUrls.UserWebProfiles(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Track>> GetLikedTracksAsync(string userUrn, GetLikedUserTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserLikedTracks(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Playlist>> GetLikedPlaylistsAsync(string userUrn, GetLikedUserPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserLikedPlaylists(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Track>> GetRepostTracksAsync(string userUrn, GetUserRepostsTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserRepostedTracks(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Playlist>> GetRepostPlaylistsAsync(string userUrn, GetUserPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserRepostedPlaylists(userUrn), query, cancellationToken).ConfigureAwait(false);
    }
}