namespace SoundCloudSharp.Api.Models.Response;

public record FullUser : BasicUser
{
    public string City { get; init; }
    public string Country { get; init; }
    public string Description { get; init; }
    public string DiscogsName { get; init; }
    public string FirstName { get; init; }
    public string FullName { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public string LastName { get; init; }
    public string Plan { get; init; }
    public int PlaylistCount { get; init; }
    public int PublicFavoritesCount { get; init; }
    public int TrackCount { get; init; }
    public Uri Website { get; init; }
    public string WebsiteTitle { get; init; }
}