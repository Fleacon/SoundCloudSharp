using SoundCloudSharp.Api.Authenticators;
using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Endpoints;

public class SoundCloudConfig(HttpService httpService, ISerializer serializer, IAuthenticator? authenticator)
{
    public HttpService HttpService { get; } = httpService;
    public ISerializer Serializer { get; } = serializer;
    public IAuthenticator? Authenticator { get; } = authenticator;

    public static SoundCloudConfig CreateUnauthorized()
    {
        return new SoundCloudConfig(
            new HttpService(),
            new NewtonsoftJsonSerializer(),
            null);
    }
    
    public static SoundCloudConfig CreateDefault(IAuthenticator authenticator)
    {
        return new SoundCloudConfig(
            new HttpService(),
            new NewtonsoftJsonSerializer(),
            authenticator);
    }

    public SoundCloudConfig WithHttpService(HttpService service)
    {
        return new SoundCloudConfig(
            service,
            Serializer,
            Authenticator);
    }

    public SoundCloudConfig WithSerializer(ISerializer serializer)
    {
        return new SoundCloudConfig(
            httpService,
            serializer,
            Authenticator);
    }
}