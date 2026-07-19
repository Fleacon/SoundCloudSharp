namespace SoundCloudSharp.Api.Models.Request;

public record SearchUsersRequest
{
    public string? Query { get; init; }
    public string[]? Urns { get; init; }
    public PagedRequest? Page { get; init; } = new();
}