namespace SoundCloudSharp.Api.Models.Request;

public interface IQueryParameterContainer;

public record PagingOptions : IQueryParameterContainer
{
    /// <summary>
    /// Number of results to return in the collection.
    /// </summary>
    /// <remarks>If <see langword="null"/> or omitted, the request uses SoundCloud's default value : 50</remarks>
    [QueryParam("limit")]
    public int? Limit { get; init; }
    /// <summary>
    /// Returns paginated collection of items
    /// </summary>
    [QueryParam("linked_partitioning")]
    public bool LinkedPartitioning => true;
}