using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetUserTracksRequest
{
    public PagingOptions Paging { get; init; } = new ();
    public Enums.Access[]? Access { get; init; }
    public Enums.Sort? Sort { get; init; }
}