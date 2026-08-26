namespace SoundCloudSharp.Api.Models.Response;

public record FullUser : BasicUser
{
    /// <summary>
    /// city
    /// </summary>
    public string City { get; init; }
    /// <summary>
    /// country
    /// </summary>
    public string Country { get; init; }
    /// <summary>
    /// description
    /// </summary>
    public string Description { get; init; }
    /// <summary>
    /// discogs name
    /// </summary>
    public string DiscogsName { get; init; }
    /// <summary>
    /// first name
    /// </summary>
    public string FirstName { get; init; }
    /// <summary>
    /// first and last name
    /// </summary>
    public string FullName { get; init; }
    /// <summary>
    /// profile creation datetime
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; }
    /// <summary>
    /// last name
    /// </summary>
    public string LastName { get; init; }
    /// <summary>
    /// subscription plan of the user
    /// </summary>
    public string Plan { get; init; }
    /// <summary>
    /// number of public playlists
    /// </summary>
    public int PlaylistCount { get; init; }
    /// <summary>
    /// number of favorited public tracks
    /// </summary>
    public int PublicFavoritesCount { get; init; }
    /// <summary>
    /// number of public tracks
    /// </summary>
    public int TrackCount { get; init; }
    /// <summary>
    /// a URL to the website
    /// </summary>
    public Uri Website { get; init; }
    /// <summary>
    /// a custom title for the website
    /// </summary>
    public string WebsiteTitle { get; init; }
}