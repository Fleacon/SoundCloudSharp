namespace SoundCloudSharp.Api.Models.Request;

public record GetTrackRepostersRequest
{
    public PagingOptions Paging { get; init; } = new();
}