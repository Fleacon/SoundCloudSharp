namespace SoundCloudSharp.Api.utils;

public static class FileTypeUtil
{
    public static string GetAudioContentType(string filename) => Path.GetExtension(filename).ToLowerInvariant() switch
    {
        ".mp3" => "audio/mpeg",
        ".wav" => "audio/wav",
        ".flac" => "audio/flac",
        ".ogg" => "audio/ogg",
        _ => "application/octet-stream"
    };

    public static string GetImageContentType(string filename) => Path.GetExtension(filename).ToLowerInvariant() switch
    {
        ".png" => "image/png",
        ".jpeg" => "image/jpeg",
        ".gif" => "image/gif",
        _ => throw new Exception("Unknown image format.")
    };
}