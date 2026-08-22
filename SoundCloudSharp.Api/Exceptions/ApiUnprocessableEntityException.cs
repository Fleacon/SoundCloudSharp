using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiUnprocessableEntityException(IFailedResponse response) : ApiException(response);