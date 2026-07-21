using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetMeRepostsTracksRequest
{
    public PagingOptions Paging { get; init; } = new();
    public Enums.Access[]? Access { get; init; }
}