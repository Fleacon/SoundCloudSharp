using System.Security.Cryptography;
using System.Text;

namespace SoundCloudSharp.Api.utils;

public static class PKCEUtil
{
    public static string GenerateCodeVerifier()
    {
        return Guid.NewGuid().ToString();
    }

    public static string GenerateCodeChallenge(string codeVerifier)
    {
        var verifierBytes = Encoding.UTF8.GetBytes(codeVerifier);
        var challengeBytes = SHA256.HashData(verifierBytes);
        return Base64Util.Encode(challengeBytes);
    }
}