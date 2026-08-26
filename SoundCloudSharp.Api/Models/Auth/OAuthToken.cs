namespace SoundCloudSharp.Api.Models.Auth;

public record OAuthToken
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
    public int ExpiresIn { get; init; }
    public string? Scope { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public bool IsExpired => CreatedAt.AddSeconds(ExpiresIn) <= DateTime.UtcNow;
}