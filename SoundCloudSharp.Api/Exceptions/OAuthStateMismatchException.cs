namespace SoundCloudSharp.Api.Exceptions;

public class OAuthStateMismatchException(string message) : Exception(message);