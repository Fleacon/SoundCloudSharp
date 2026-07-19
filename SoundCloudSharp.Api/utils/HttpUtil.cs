using System.Net;

namespace SoundCloudSharp.Api.utils;

public static class HttpUtil
{
    public static bool StatusCodeIsSuccess(HttpStatusCode statusCode)
    {
        return ((int)statusCode >= 200) && ((int)statusCode <= 299);
    }
}