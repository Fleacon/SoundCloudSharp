namespace SoundCloudSharp.Api.Models.Auth;

public record AuthorizationCodeUri(Uri AuthorizationUri, string CodeVerifier, string State);
