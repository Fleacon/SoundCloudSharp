using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiForbiddenException(ErrorResponse response) : ApiException(response);