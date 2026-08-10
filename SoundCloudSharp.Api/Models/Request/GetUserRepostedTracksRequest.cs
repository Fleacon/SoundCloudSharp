using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetUserRepostedTracksRequest
{
    public PagingOptions Paging { get; init; } = new();
    [QueryParam("access")]
    public Enums.Access[]? Access { get; init; }
}