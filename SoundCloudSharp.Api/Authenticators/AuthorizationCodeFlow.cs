using System.Web;
using SoundCloudSharp.Api.Models.Auth;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Authenticators;

public class AuthorizationCodeFlow
{
    public ClientSecrets ClientSecrets { get; }
    public Uri RedirectUri { get; }
    public string State { get; }
    public string CodeVerifier { get; }
    public string CodeChallenge { get; }

    public AuthorizationCodeFlow(ClientSecrets clientSecret, Uri redirectUri)
    {
        ClientSecrets = clientSecret;
        RedirectUri = redirectUri;
        State = Guid.NewGuid().ToString();
        CodeVerifier = PKCEUtil.GenerateCodeVerifier();
        CodeChallenge = PKCEUtil.GenerateCodeChallenge(CodeVerifier);
    }

    public Uri CreateAuthorizationCodeUri()
    {
        var builder = new UriBuilder(SoundCloudUrls.AuthorizationUri);
        var query = HttpUtility.ParseQueryString(string.Empty);

        query["client_id"] = ClientSecrets.ClientId;
        query["redirect_uri"] = RedirectUri.AbsoluteUri;
        query["response_type"] = "code";
        query["code_challenge"] = CodeChallenge;
        query["code_challenge_method"] = "S256";
        query["state"] = State;
        
        builder.Query = query.ToString();
        return builder.Uri;
    }

    public AuthorizationCodeTokenRequest CreateAuthorizationCodeTokenRequest(Uri callbackUri)
    {
        var code = HttpUtility.ParseQueryString(callbackUri.ToString())["code"];
        return code is null ? throw new("No Authorization Code from Callback") : new AuthorizationCodeTokenRequest(ClientSecrets, RedirectUri, code, CodeVerifier);
    }
}