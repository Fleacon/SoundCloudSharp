namespace SoundCloudSharp.Api.Http;

public record Request(Uri BaseAddress, Uri Endpoint, HttpMethod Method)
{
    public IDictionary<string, string> Headers { get; init; } = new Dictionary<string, string>();
    public IDictionary<string, string>? Parameters { get; init; }
    public object? Body { get; init; }
}