using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api;

public static class SoundCloudUrls
{
    public static readonly Uri BaseUri = new("https://api.soundcloud.com/");
    public static readonly Uri AuthorizationUri = new("https://secure.soundcloud.com/authorize");
    public static readonly Uri OAuthTokenUri = new("https://secure.soundcloud.com/oauth/token");
    
    public static Uri Me() => new("me", UriKind.Relative);
    public static Uri Feed() => new("me/feed", UriKind.Relative);
    public static Uri FeedTracks() => new("me/feed/tracks", UriKind.Relative);
    public static Uri RecentlyPlayedTracks() => new("me/recently-played/tracks", UriKind.Relative);
    public static Uri LikedTracks() => new("me/likes/tracks", UriKind.Relative);
    public static Uri LikedPlaylists() => new("me/likes/playlists", UriKind.Relative);
    public static Uri Followings() => new("me/followings", UriKind.Relative);
    public static Uri FollowingsTracks() => new("me/followings/tracks", UriKind.Relative);
    public static Uri Follow(string userUrn) => new($"me/followings/{Uri.EscapeDataString(userUrn)}", UriKind.Relative);
    public static Uri Followers() => new("me/followers", UriKind.Relative);
    public static Uri MePlaylists() => new("me/playlists", UriKind.Relative);
    public static Uri MeTracks() => new("me/tracks", UriKind.Relative);
    public static Uri MeRepostTracks() => new("me/reposts/tracks", UriKind.Relative);
    public static Uri MeRepostPlaylists() => new("me/reposts/playlists", UriKind.Relative);
    
    public static Uri Tracks() => new("tracks", UriKind.Relative);
    public static Uri Playlists() => new("playlists", UriKind.Relative);
    public static Uri Users() => new("users", UriKind.Relative);
    
    public static Uri Playlist(string playlistUrn) => new($"playlists/{Uri.EscapeDataString(playlistUrn)}", UriKind.Relative);
    public static Uri PlaylistTracks(string playlistUrn) => new($"playlists/{Uri.EscapeDataString(playlistUrn)}/tracks", UriKind.Relative);
    public static Uri PlaylistReposters(string playlistUrn) => new($"playlists/{Uri.EscapeDataString(playlistUrn)}/reposters", UriKind.Relative);
    
    public static Uri Track(string trackUrn) =>  new($"tracks/{Uri.EscapeDataString(trackUrn)}", UriKind.Relative);
    public static Uri TrackStorefront(string trackUrn)  => new($"tracks/{Uri.EscapeDataString(trackUrn)}/storefront", UriKind.Relative);
    public static Uri TrackPreview(string trackUrn) => new($"tracks/{Uri.EscapeDataString(trackUrn)}/preview", UriKind.Relative);
    public static Uri TrackStreams(string trackUrn) => new($"tracks/{Uri.EscapeDataString(trackUrn)}/streams", UriKind.Relative);
    public static Uri TrackComments(string trackUrn) => new($"tracks/{Uri.EscapeDataString(trackUrn)}/comments", UriKind.Relative);
    public static Uri TrackFavoriters(string trackUrn)  => new($"tracks/{Uri.EscapeDataString(trackUrn)}/favoriters", UriKind.Relative);
    public static Uri TrackReposters(string trackUrn) => new($"tracks/{Uri.EscapeDataString(trackUrn)}/reposters", UriKind.Relative);
    public static Uri TrackRelated(string trackUrn) => new($"tracks/{Uri.EscapeDataString(trackUrn)}/related", UriKind.Relative);
    
    public static Uri User(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}", UriKind.Relative);
    public static Uri UserRelated(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/related", UriKind.Relative);
    public static Uri UserFollowers(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/followers", UriKind.Relative);
    public static Uri UserFollowings(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/followings", UriKind.Relative);
    public static Uri UserPlaylists(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/playlists", UriKind.Relative);
    public static Uri UserTracks(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/tracks", UriKind.Relative);
    public static Uri UserWebProfiles(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/web-profiles", UriKind.Relative);
    public static Uri UserLikedTracks(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/likes/tracks", UriKind.Relative);
    public static Uri UserLikedPlaylists(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/likes/playlists", UriKind.Relative);
    public static Uri UserRepostedTracks(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/reposts/tracks", UriKind.Relative);
    public static Uri UserRepostedPlaylists(string userUrn) => new($"users/{Uri.EscapeDataString(userUrn)}/reposts/playlists", UriKind.Relative);
    
    public static Uri LikeTracks(string trackUrn) => new($"likes/tracks/{Uri.EscapeDataString(trackUrn)}", UriKind.Relative);
    public static Uri LikePlaylists(string playlistUrn)  => new($"likes/playlists/{Uri.EscapeDataString(playlistUrn)}", UriKind.Relative);
    
    public static Uri RepostTracks(string trackUrn) => new($"reposts/tracks/{Uri.EscapeDataString(trackUrn)}", UriKind.Relative);
    public static Uri RepostPlaylists(string playlistUrn) => new($"reposts/playlists/{Uri.EscapeDataString(playlistUrn)}", UriKind.Relative);
    
    public static Uri Resolve() => new("resolve", UriKind.Relative);
    
    public static Uri SignOut() => new("sign-out", UriKind.Relative);
} 