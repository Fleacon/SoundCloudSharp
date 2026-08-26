namespace SoundCloudSharp.Api.Models.Response;

/// <summary>
/// User's Comment
/// </summary>
public record Comment
{
    /// <summary>
    /// Comment body.
    /// </summary>
    public string Body { get; init; }
    /// <summary>
    /// Created timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; }
    /// <summary>
    /// Identifier.
    /// </summary>
    public string Urn { get; init; }
    /// <summary>
    /// Kind (comment).
    /// </summary>
    public string Kind { get; init; }
    /// <summary>
    /// User's identifier.
    /// </summary>
    public string UserUrn { get; init; }
    /// <summary>
    /// Timestamp.
    /// </summary>
    public string TimeStamp { get; init; }
    /// <summary>
    /// Track's identifier.
    /// </summary>
    public string TrackUrn { get; init; }
    /// <summary>
    /// Comment's URL.
    /// </summary>
    public Uri Uri { get; init; }
    /// <summary>
    /// SoundCloud User object
    /// </summary>
    public BasicUser User { get; init; }
}