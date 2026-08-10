namespace SoundCloudSharp.Api.Models.Request;

public record GetUserRepostedPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
}