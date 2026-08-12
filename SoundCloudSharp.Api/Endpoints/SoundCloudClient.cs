using SoundCloudSharp.Api.Authenticators;
using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Auth;

namespace SoundCloudSharp.Api.Endpoints;

public class SoundCloudClient
{
    public MeEndpoint Me { get; private set; }
    public SearchEndpoint Search { get; private set; }
    public PlaylistsEndpoint Playlists { get; private set; }
    public TracksEndpoint Tracks { get; private set; }
    public UsersEndpoint Users { get; private set; }
    public LikesEndpoint Likes { get; private set; }
    public RepostsEndpoint Reposts { get; private set; }
    public MiscellaneousEndpoint Miscellaneous { get; private set; }
    public DefaultEndpoint Default { get; private set; }
    public OAuthEndpoint OAuth { get; private set; }
    
    private readonly ApiConnector _connector;
    
    public SoundCloudClient()
    {
        _connector = new ApiConnector();
        InitializeEndpoints();
    }

    public SoundCloudClient(ClientSecrets clientSecrets, OAuthToken oAuthToken)
    {
        IAuthenticator authenticator = oAuthToken.Auth switch
        {
            AuthType.AuthorizationCode => new AuthorizationCodeAuthenticator(clientSecrets, oAuthToken),
            AuthType.ClientCredentials => new ClientCredentialsAuthenticator(clientSecrets, oAuthToken),
            _ => throw new ArgumentOutOfRangeException(nameof(oAuthToken.Auth))
        };
        _connector = new ApiConnector(authenticator);
        InitializeEndpoints();
    }

    public SoundCloudClient(string accessToken)
    {
        IAuthenticator authenticator = new StaticTokenAuthenticator(accessToken);
        _connector = new ApiConnector(authenticator);
        InitializeEndpoints();
    }

    public SoundCloudClient(ClientSecrets clientSecrets)
    {
        
    }

    private void InitializeEndpoints()
    {
        Me = new(_connector);
        Search = new(_connector);
        Playlists = new(_connector);
        Tracks = new(_connector);
        Users = new(_connector);
        Likes = new(_connector);
        Reposts = new(_connector);
        Miscellaneous = new(_connector);
        Default = new(_connector);
        OAuth = new(_connector);
    }
}