using SoundCloudSharp.Api.Models.Request.Paging;

namespace SoundCloudSharp.Api.Models.Request;

public record SearchUsersRequest
{
    public string? Query { get; init; }
    public string[]? Urns { get; init; }
    public PagingOptions? Page { get; init; } = new();
}