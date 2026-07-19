namespace SoundCloudSharp.Api.Models.Request;

public interface IQueryParameterContainer { }

public record PagedRequest : IQueryParameterContainer
{
    public int? Limit { get; init; }
    public bool LinkedPartitioning { get; init; } = true;
}