namespace SoundCloudSharp.Api.Models.Response;

public class Quota
{
    /// <summary>
    /// unlimited upload quota.
    /// </summary>
    public bool UnlimitedUploadQuota { get; init; }
    /// <summary>
    /// upload seconds used.
    /// </summary>
    public int UploadSecondsUsed  { get; init; }
    /// <summary>
    /// upload seconds left.
    /// </summary>
    public int? UploadSecondsLeft { get; init; }
}