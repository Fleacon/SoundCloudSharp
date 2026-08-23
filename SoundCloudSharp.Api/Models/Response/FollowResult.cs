namespace SoundCloudSharp.Api.Models.Response;

public record FollowResult
{
    public bool WasAlreadyFollowing { get; init; }
    public FullUser? User { get; init; }
}