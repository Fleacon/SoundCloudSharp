namespace SoundCloudSharp.Api.Exceptions;

public class ApiInternalServerErrorException(string message) : ApiException(message);