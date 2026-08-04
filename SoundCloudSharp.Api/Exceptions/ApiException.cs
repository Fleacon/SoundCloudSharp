using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;


public class ApiException : Exception
{
    protected IFailedResponse? Response { get; init; }

    public ApiException(IFailedResponse response)
    {
        Response = response;
    }
    
    public ApiException() {}
}