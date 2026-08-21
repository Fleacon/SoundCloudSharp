namespace SoundCloudSharp.Api.Exceptions;

public class ApiInternalServerError(string message) : ApiException(message);