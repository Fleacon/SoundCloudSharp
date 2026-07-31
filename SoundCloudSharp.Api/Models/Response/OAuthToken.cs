namespace SoundCloudSharp.Api.Models.Response;

public record OAuthToken
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
    public int ExpiresIn { get; init; }
    public string Scope { get; init; }
    
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public bool IsExpired => CreatedAt.AddSeconds(ExpiresIn) <= DateTime.UtcNow;
}