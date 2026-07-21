using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetMeRepostsPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
}