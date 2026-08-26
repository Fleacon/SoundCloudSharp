namespace SoundCloudSharp.Api.Models.Response;

/// <summary>
/// User's links added to their profile
/// </summary>
public record WebProfiles
{
    /// <summary>
    /// Timestamp of when the link was added to the profile.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; }
    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; init; }
    /// <summary>
    /// Kind
    /// </summary>
    public string Kind { get; init; }
    /// <summary>
    /// Service or platform
    /// </summary>
    public string Service { get; init; }
    /// <summary>
    /// Link's title
    /// </summary>
    public string Title { get; init; }
    /// <summary>
    /// URL of the external link
    /// </summary>
    public Uri Url { get; init; }
    /// <summary>
    /// Username extracted from the external link
    /// </summary>
    public string Username { get; init; }
}