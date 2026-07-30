using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetUserPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new ();
    public Enums.Access[]? Access { get; init; }
    public bool ShowTracks { get; init; }
}