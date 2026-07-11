using System.Net;

namespace SoundCloudSharp.Api.Models.Response;

public record ErrorResponse
{
    public HttpStatusCode Code { get; init; }
    public string Message { get; init; }
    public Uri Link { get; init; }
}