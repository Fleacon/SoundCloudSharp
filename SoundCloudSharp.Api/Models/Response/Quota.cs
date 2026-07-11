namespace SoundCloudSharp.Api.Models.Response;

public class Quota
{
    public bool UnlimitedUploadQuota { get; init; }
    public int UploadSecondsUsed  { get; init; }
    public int? UploadSecondsLeft { get; init; }
}