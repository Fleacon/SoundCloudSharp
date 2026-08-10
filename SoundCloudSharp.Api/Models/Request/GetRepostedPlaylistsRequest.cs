namespace SoundCloudSharp.Api.Models.Request;

public record GetRepostedPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
}