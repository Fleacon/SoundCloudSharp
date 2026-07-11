namespace SoundCloudSharp.Api.Models.Response;

public record WebProfiles
{
    public DateTimeOffset CreatedAt { get; init; }
    public string Id { get; init; }
    public string Kind { get; init; }
    public string Service { get; init; }
    public string Title { get; init; }
    public Uri Url { get; init; }
    public string Username { get; init; }
}