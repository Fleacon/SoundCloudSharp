namespace SoundCloudSharp.Api.Models.Request;

public interface IQueryParameterContainer { }

public record PagedRequest : IQueryParameterContainer
{
    public int? Limit { get; init; } = 50;
    public bool LinkedPartitioning { get; init; } = true;
}