namespace SoundCloudSharp.Api.Models.Response;

public record Me : FullUser
{
    /// <summary>
    /// likes count
    /// </summary>
    public int LikesCount { get; init; }
    /// <summary>
    /// locale
    /// </summary>
    public string? Locale  { get; init; }
    /// <summary>
    /// online
    /// </summary>
    public bool Online { get; init; }
    /// <summary>
    /// boolean if email is confirmed.
    /// </summary>
    public bool PrimaryEmailConfirmed { get; init; }
    /// <summary>
    /// number of private playlists.
    /// </summary>
    public int PrivatePlaylistsCount { get; init; }
    /// <summary>
    /// number of private tracks.
    /// </summary>
    public int PrivateTracksCount { get; init; }
    /// <summary>
    /// user's upload quota
    /// </summary>
    public Quota Quota { get; init; }
    /// <summary>
    /// a list subscriptions associated with the user
    /// </summary>
    public List<Subscription> Subscriptions { get; init; }
    /// <summary>
    /// upload seconds left.
    /// </summary>
    public int? UploadSecondsLeft { get; init; }
}