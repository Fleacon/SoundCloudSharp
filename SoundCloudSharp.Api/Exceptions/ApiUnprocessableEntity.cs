using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiUnprocessableEntity(IFailedResponse response) : ApiException(response);