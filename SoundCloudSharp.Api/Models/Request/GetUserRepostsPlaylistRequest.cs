namespace SoundCloudSharp.Api.Models.Request;

public record GetUserRepostsPlaylistRequest
{
    public PagingOptions Paging { get; init; } = new();
}