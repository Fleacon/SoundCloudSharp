using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiNotFoundExcpetion(IFailedResponse response) : ApiException(response);