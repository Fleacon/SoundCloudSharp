namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetTrackFavoritersRequest
{
    public PagingOptions Paging { get; init; } = new();
}