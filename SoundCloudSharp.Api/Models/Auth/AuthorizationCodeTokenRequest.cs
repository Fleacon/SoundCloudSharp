namespace SoundCloudSharp.Api.Models.Auth;

public record AuthorizationCodeTokenRequest(ClientSecrets ClientSecrets, Uri RedirectUri, string Code, string CodeVerifier);