using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Authenticators;

public class StaticTokenAuthenticator(string accessToken) : IAuthenticator
{
    public Task Apply(Request request, ApiConnector connector, CancellationToken cancellationToken = default)
    {
        request.Headers["Authorization"] = $"OAuth {accessToken}";
        return Task.CompletedTask;
    }
}