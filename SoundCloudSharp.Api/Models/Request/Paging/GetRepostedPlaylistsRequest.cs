namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetRepostedPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
}