using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiFailedSerializationException(Response rawResponse, string message) : Exception(message)
{
    public Response RawResponse { get; } = rawResponse;
}