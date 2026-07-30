namespace SoundCloudSharp.Api.utils;

public static class FileTypeUtil
{
    // https://help.soundcloud.com/hc/en-us/articles/360039171614-Upload-Requirements#:~:text=Supported%20audio%20file%20formats
    public static string GetAudioContentType(string filename) => Path.GetExtension(filename).ToLowerInvariant() switch
    {
        ".mp3" or ".mp2" => "audio/mpeg",
        ".wav" => "audio/wav",
        ".flac" => "audio/flac",
        ".ogg" => "audio/ogg",
        ".aiff" => "audio/aiff",
        ".aac" => "audio/aac",
        ".mp4" or ".m4a" => "audio/mp4",
        ".3gp" => "video/3gp",
        ".3g2" => "audio/3gpp2",
        ".mj2" => "video/mj2",
        ".wma" => "audio/x-ms-wma",
        ".amr" => "audio/amr",
        _ => throw new Exception("Unknown audio format.")
    };

    public static string GetImageContentType(string filename) => Path.GetExtension(filename).ToLowerInvariant() switch
    {
        ".png" => "image/png",
        ".jpeg" => "image/jpeg",
        ".gif" => "image/gif",
        _ => throw new Exception("Unknown image format.")
    };
}