using System.Net;

namespace SoundCloudSharp.Api.Models.Response;

public interface IFailedResponse
{
    public HttpStatusCode Code { get; init; }
    public string Message { get; init; }
    public Uri Link { get; init; }
}