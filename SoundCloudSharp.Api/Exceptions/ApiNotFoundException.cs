using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiNotFoundException(IFailedResponse response) : ApiException(response);