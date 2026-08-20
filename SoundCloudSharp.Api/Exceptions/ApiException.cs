using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;


public class ApiException : Exception
{
    public IFailedResponse Response { get; init; }

    public ApiException(IFailedResponse response) : base($"API {response.Code}: {response.Message}")
    {
        Response = response;
    }
    
    public ApiException(string message) : base(message) {}
    
    public ApiException(string message, Exception inner) : base(message, inner) {}
}