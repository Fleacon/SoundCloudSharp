namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetUserRepostedPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new ();
}