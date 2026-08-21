namespace SoundCloudSharp.Api.Models.Request;

public record SearchUsersRequest
{
    [QueryParam("q")]
    public string? Query { get; init; }
    [QueryParam("urns")]
    public string[]? Urns { get; init; }
    public PagingOptions? Page { get; init; } = new();
}