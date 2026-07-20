using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api;

public static class SoundCloudUrls
{
    public static readonly Uri BaseUri = new("https://api.soundcloud.com");
    
    public static Uri Me() => new("/me");
    public static Uri Feed() => new("/me/feed");
    public static Uri FeedTracks() => new("/me/feed/tracks");
    public static Uri RecentlyPlayedTracks() => new("/me/recently-played/tracks");
    public static Uri LikedTracks() => new("/me/likes/tracks");
    public static Uri LikedPlaylists() => new("/me/likes/playlists");
    public static Uri Followings() => new("/me/followings");
    public static Uri FollowingsTracks() => new("/me/followings/tracks");
    public static Uri Follow(string userUrn) => new($"/me/followings/{Uri.EscapeDataString(userUrn)}");
    public static Uri Followers() => new("/me/followers");
    public static Uri MePlaylists() => new("/me/playlists");
    public static Uri MeTracks() => new("/me/tracks");
    public static Uri RepostTracks() => new("/me/reposts/tracks");
    public static Uri RepostPlaylists() => new("/me/reposts/playlists");
    
    public static Uri Tracks() => new("/tracks");
    public static Uri Playlists() => new("/playlists");
    public static Uri Users() => new("/users");
    
    public static Uri Playlist(string playlistUrn) => new($"/playlists/{Uri.EscapeDataString(playlistUrn)}");
    public static Uri PlaylistTracks(string playlistUrn) => new($"/playlists/{Uri.EscapeDataString(playlistUrn)}/tracks");
    public static Uri PlaylistReposters(string playlistUrn) => new($"/playlists/{Uri.EscapeDataString(playlistUrn)}/reposters");
    
    public static Uri Track(string trackUrn) =>  new($"/tracks/{Uri.EscapeDataString(trackUrn)}");
    public static Uri TrackStorefront(string trackUrn)  => new($"/tracks/{Uri.EscapeDataString(trackUrn)}/storefront");
    public static Uri TrackPreview(string trackUrn) => new($"/tracks/{Uri.EscapeDataString(trackUrn)}/preview");
    public static Uri TrackStreams(string trackUrn) => new($"/tracks/{Uri.EscapeDataString(trackUrn)}/streams");
    public static Uri TrackComments(string trackUrn) => new($"/tracks/{Uri.EscapeDataString(trackUrn)}/comments");
    public static Uri TrackFavoriters(string trackUrn)  => new($"/tracks/{Uri.EscapeDataString(trackUrn)}/favoriters");
    public static Uri TrackReposters(string trackUrn) => new($"/tracks/{Uri.EscapeDataString(trackUrn)}/reposters");
    public static Uri TrackRelated(string trackUrn) => new($"/tracks/{Uri.EscapeDataString(trackUrn)}/related");
    
    public static Uri User(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}");
    public static Uri UserRelated(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/related");
    public static Uri UserFollowers(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/followers");
    public static Uri UserFollowings(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/followings");
    public static Uri UserPlaylists(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/playlists");
    public static Uri UserTracks(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/tracks");
    public static Uri UserWebProfiles(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/web-profiles");
    public static Uri UserLikedTracks(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/likes/tracks");
    public static Uri UserLikedPlaylists(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/likes/playlists");
    public static Uri UserRepostedTracks(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/reposts/tracks");
    public static Uri UserRepostedPlaylists(string userUrn) => new($"/users/{Uri.EscapeDataString(userUrn)}/reposts/playlists");
    
    public static Uri LikeTracks(string trackUrn) => new($"/likes/tracks/{Uri.EscapeDataString(trackUrn)}");
    public static Uri LikePlaylists(string playlistUrn)  => new($"/likes/playlists/{Uri.EscapeDataString(playlistUrn)}");
    
    public static Uri RepostTracks(string trackUrn) => new($"/reposts/tracks/{Uri.EscapeDataString(trackUrn)}");
    public static Uri RepostPlaylists(string playlistUrn) => new($"/reposts/playlists/{Uri.EscapeDataString(playlistUrn)}");
    
    public static Uri Resolve() => new("/resolve");
    
    public static Uri SignOut() => new("/sign-out");
} 