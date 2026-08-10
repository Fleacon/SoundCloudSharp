using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetMeFollowingsTracksRequest
{
    public PagingOptions PagingOptions { get; init; } = new();
    [QueryParam("access")]
    public Enums.Access[]? Access { get; init; }
}