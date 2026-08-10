namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetUserRepostsPlaylistRequest
{
    public PagingOptions Paging { get; init; } = new();
}