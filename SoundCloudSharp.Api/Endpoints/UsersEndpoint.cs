using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request.Paging;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Endpoints;

public class UsersEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<FullUser> GetUserAsync(string userUrn, CancellationToken cancellationToken = default)
    {
        return await Connector.GetAsync<FullUser>(SoundCloudUrls.User(userUrn), cancellationToken); 
    }

    public async Task<Paging<FullUser?>> GetRelatedArtistsAsync(string userUrn,
        GetUserRelatedArtistsRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.UserRelated(userUrn), query, cancellationToken);
    }

    public async Task<Paging<FullUser?>> GetFollowersAsync(string userUrn, int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.UserFollowers(userUrn), query, cancellationToken);
    }

    public async Task<Paging<FullUser?>> GetFollowingsAsync(string userUrn, int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.UserFollowings(userUrn), query, cancellationToken);
    }

    public async Task<Paging<Playlist>> GetPlaylists(string userUrn, GetUserPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserPlaylists(userUrn), query, cancellationToken);
    }

    public async Task<Paging<Track>> GetTracks(string userUrn, GetUserTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserTracks(userUrn), query, cancellationToken);
    }

    public async Task<WebProfiles> GetWebProfile(string userUrn, int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit);
        return await Connector.GetAsync<WebProfiles>(SoundCloudUrls.UserWebProfiles(userUrn), query, cancellationToken);
    }

    public async Task<Paging<Track>> GetLikedTracks(string userUrn, GetLikedUserTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserLikedTracks(userUrn), query, cancellationToken);
    }

    public async Task<Paging<Playlist>> GetLikedPlaylists(string userUrn, GetLikedUserPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserLikedPlaylists(userUrn), query, cancellationToken);
    }

    public async Task<Paging<Track>> GetRepostTracks(string userUrn, GetUserRepostsTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserRepostedTracks(userUrn), query, cancellationToken);
    }

    public async Task<Paging<Playlist>> GetRepostPlaylists(string userUrn, GetUserPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserRepostedPlaylists(userUrn), query, cancellationToken);
    }
}