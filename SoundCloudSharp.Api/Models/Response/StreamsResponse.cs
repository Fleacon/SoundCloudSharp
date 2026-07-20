namespace SoundCloudSharp.Api.Models.Response;

public record StreamsResponse
{
    public Uri HlsAac160Url { get; init; }
    public Uri HlsMp3128Url { get; init; }
    public Uri PreviewMp3128Url { get; init; }
}