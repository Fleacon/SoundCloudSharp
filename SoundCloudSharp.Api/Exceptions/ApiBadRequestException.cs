using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiBadRequestException(ErrorResponse response) : ApiException(response);