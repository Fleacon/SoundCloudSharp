namespace SoundCloudSharp.Api.Models.Request;

public record GetMeRepostsPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
}