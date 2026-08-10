using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetUserTracksRequest
{
    public PagingOptions Paging { get; init; } = new();
    [QueryParam("access")]
    public Enums.Access[]? Access { get; init; }
    [QueryParam("sort")]
    public Enums.Sort? Sort { get; init; }
}