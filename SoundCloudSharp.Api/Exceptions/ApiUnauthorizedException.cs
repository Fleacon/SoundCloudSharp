using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiUnauthorizedException(ErrorResponse response) : ApiException(response);