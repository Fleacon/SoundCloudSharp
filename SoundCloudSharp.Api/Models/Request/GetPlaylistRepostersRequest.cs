namespace SoundCloudSharp.Api.Models.Request;

public record GetPlaylistRepostersRequest
{
    public PagingOptions Paging { get; init; } = new();
}