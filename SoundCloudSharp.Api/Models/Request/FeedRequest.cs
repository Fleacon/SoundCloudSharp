using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record FeedRequest
{
    public Enums.Access[]? Access { get; init; }
    public int? Limit { get; init; }
}