namespace SoundCloudSharp.Api.Models.Response;

public record BasicUser
{
    /// <summary>
    /// unique identifier
    /// </summary>
    public string Urn { get; init; }
    /// <summary>
    /// kind of resource
    /// </summary>
    public string Kind { get; init; }
    /// <summary>
    /// permalink of the resource
    /// </summary>
    public string Permalink { get; init; }
    /// <summary>
    /// username
    /// </summary>
    public string Username { get; init; }
    /// <summary>
    /// last modified datetime
    /// </summary>
    public DateTimeOffset LastModified { get; init; }
    /// <summary>
    /// API resource URL
    /// </summary>
    public Uri Uri { get; init; }
    /// <summary>
    /// URL to the SoundCloud.com page
    /// </summary>
    public Uri PermalinkUrl { get; init; }
    /// <summary>
    /// URL to a JPEG image
    /// </summary>
    public Uri AvatarUrl { get; init; }
    /// <summary>
    /// number of followers
    /// </summary>
    public int FollowersCount  { get; init; }
    /// <summary>
    /// number of followed users
    /// </summary>
    public int FollowingsCount { get; init; }
    /// <summary>
    /// number of reposts from user
    /// </summary>
    public int RepostsCount { get; init; }
}