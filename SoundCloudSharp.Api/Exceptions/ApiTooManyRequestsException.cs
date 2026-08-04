using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiTooManyRequestsException(TooManyRequestsResponse response) : ApiException(response);