namespace SoundCloudSharp.Api.Models.Response;

public record Comment
{
    public string Body { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public string Urn { get; init; }
    public string Kind { get; init; }
    public string UserUrn { get; init; }
    public string TimeStamp { get; init; }
    public string TrackUrn { get; init; }
    public Uri Uri { get; init; }
    public BasicUser User { get; init; }
}