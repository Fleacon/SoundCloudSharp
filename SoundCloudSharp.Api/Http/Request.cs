namespace SoundCloudSharp.Api.Http;

public record Request(Uri Endpoint, HttpMethod Method)
{
    public IDictionary<string, string> Headers { get; init; }
    public IDictionary<string, string> Parameters { get; init; }
    public object? Body { get; init; }
}