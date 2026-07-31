namespace SoundCloudSharp.Api.Models.Request;

public record RefreshTokenRequest(string ClientId, string ClientSecret, string RefreshToken);