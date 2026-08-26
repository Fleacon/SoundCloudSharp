namespace SoundCloudSharp.Api.Models.Request;

public record SearchUsersRequest
{
    /// <summary>
    /// Search query
    /// </summary>
    [QueryParam("q")]
    public string? Query { get; init; }
    /// <summary>
    /// List of track urns to filter on
    /// </summary>
    [QueryParam("urns")]
    public string[]? Urns { get; init; }
    /// <summary>
    /// Gets the pagination options to apply to the request.
    /// </summary>
    public PagingOptions? Page { get; init; } = new();
}