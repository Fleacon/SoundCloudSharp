namespace SoundCloudSharp.Api.Models.Response;

public record Me : FullUser
{
    public int LikesCount { get; init; }
    public string? Locale  { get; init; }
    public bool Online { get; init; }
    public bool PrimaryEmailConfirmed { get; init; }
    public int PrivatePlaylistsCount { get; init; }
    public int PrivateTracksCount { get; init; }
    public Quota Quota { get; init; }
    public List<Subscription> Subscriptions { get; init; }
    public int? UploadSecondsLeft { get; init; }
}