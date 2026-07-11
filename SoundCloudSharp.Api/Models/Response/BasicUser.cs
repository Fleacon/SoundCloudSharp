namespace SoundCloudSharp.Api.Models.Response;

public record BasicUser
{
    public string Urn { get; init; }
    public string Kind { get; init; }
    public string Permalink { get; init; }
    public string Username { get; init; }
    public DateTimeOffset LastModified { get; init; }
    public Uri Uri { get; init; }
    public Uri PermalinkUrl { get; init; }
    public Uri AvatarUrl { get; init; }
    public int FollowersCount  { get; init; }
    public int FollowingsCount { get; init; }
    public int RepostsCount { get; init; }
}