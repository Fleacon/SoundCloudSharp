namespace SoundCloudSharp.Api.Http;

public record DeserializedResponse<T>(Response Response, T? Content = default);