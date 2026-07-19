namespace SoundCloudSharp.Api.Models.Request;

public record RangeFilter<T> where T : struct
{
    public T? From { get; init; }
    public T? To { get; init; }
}