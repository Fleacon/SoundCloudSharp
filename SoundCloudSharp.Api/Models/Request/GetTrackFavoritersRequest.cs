namespace SoundCloudSharp.Api.Models.Request;

public record GetTrackFavoritersRequest
{
    public PagingOptions Paging { get; init; } = new();
}