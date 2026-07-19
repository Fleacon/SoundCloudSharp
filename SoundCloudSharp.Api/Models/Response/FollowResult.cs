namespace SoundCloudSharp.Api.Models.Response;

public record FollowResult
{
    public bool Followed { get; init; }
    public FullUser? User { get; init; }
}