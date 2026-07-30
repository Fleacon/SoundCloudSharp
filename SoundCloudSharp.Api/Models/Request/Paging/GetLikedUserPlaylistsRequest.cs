namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetLikedUserPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new ();
}