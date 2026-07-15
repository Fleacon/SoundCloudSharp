using System.Net;

namespace SoundCloudSharp.Api.Http;

public record Response(HttpStatusCode StatusCode, IReadOnlyDictionary<string, string> Headers)
{
    public object? Body { get; init; }
    public string? ContentType { get; init; }
}