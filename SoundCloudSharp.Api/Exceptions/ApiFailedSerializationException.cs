using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Exceptions;

public class ApiFailedSerializationException(string message, Response Response) : Exception(message);