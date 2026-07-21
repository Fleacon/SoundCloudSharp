namespace SoundCloudSharp.Api.Models.Request.Paging;

public interface IQueryParameterContainer { }

public record PagingOptions : IQueryParameterContainer
{
    public int? Limit { get; init; }
    public bool LinkedPartitioning { get; init; } = true;
}