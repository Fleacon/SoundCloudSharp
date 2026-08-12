namespace SoundCloudSharp.Api.Models.Auth;

public record AuthorizationCodeTokenRequest(ClientSecrets ClientSecrets, Uri AuthorizationUri, string Code, string CodeVerifier);