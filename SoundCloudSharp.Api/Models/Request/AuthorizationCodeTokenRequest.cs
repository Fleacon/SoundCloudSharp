namespace SoundCloudSharp.Api.Models.Request;

public record AuthorizationCodeTokenRequest(string ClientId, string ClientSecret, Uri RedirectUri, string Code, string CodeVerifier);