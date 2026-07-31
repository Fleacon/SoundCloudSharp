using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Authenticators;

public interface IAuthenticator
{
    public Task Apply(Request request, ApiConnector connector, CancellationToken cancellationToken = default);
}