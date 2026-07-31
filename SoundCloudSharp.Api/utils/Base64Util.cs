using System.Text;

namespace SoundCloudSharp.Api.utils;

public static class Base64Util
{
    public static string Encode(byte[] bytes)
    {
        return Convert.ToBase64String(bytes)
            .Replace('+', '-')
            .Replace('/', '_')
            .TrimEnd('=');
    }

    public static string Encode(string value)
    {
        var byteArr = Encoding.UTF8.GetBytes(value);
        return Encode(byteArr);
    }
}