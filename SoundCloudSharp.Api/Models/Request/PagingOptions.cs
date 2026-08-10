namespace SoundCloudSharp.Api.Models.Request;

public interface IQueryParameterContainer;

public record PagingOptions : IQueryParameterContainer
{
    [QueryParam("limit")]
    public int? Limit { get; init; }
    [QueryParam("linked_partitioning")]
    public bool LinkedPartitioning { get; init; } = true;
}