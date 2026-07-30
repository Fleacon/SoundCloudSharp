namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetUserRelatedArtistsRequest
{
    PagingOptions Paging { get; init; } = new();
}