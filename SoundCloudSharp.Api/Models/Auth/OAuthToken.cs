namespace SoundCloudSharp.Api.Models.Auth;

public record OAuthToken(string AccessToken, string RefreshToken, int ExpiresIn = 0)
{
    public string? Scope { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public bool IsExpired => CreatedAt.AddSeconds(ExpiresIn) <= DateTime.UtcNow;
}