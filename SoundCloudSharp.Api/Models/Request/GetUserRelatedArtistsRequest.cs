namespace SoundCloudSharp.Api.Models.Request;

public record GetUserRelatedArtistsRequest
{
    PagingOptions Paging { get; init; } = new();
}