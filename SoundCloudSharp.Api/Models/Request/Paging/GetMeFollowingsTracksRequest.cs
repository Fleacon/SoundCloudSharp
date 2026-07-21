using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetMeFollowingsTracksRequest
{
    public PagingOptions PagingOptions { get; init; } = new();
    public Enums.Access[]? Access { get; init; }
}