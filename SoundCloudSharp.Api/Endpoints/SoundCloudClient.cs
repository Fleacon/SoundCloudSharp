using SoundCloudSharp.Api.Authenticators;
using SoundCloudSharp.Api.Exceptions;
using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Auth;
using SoundCloudSharp.Api.Models.Response;

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

    public Task<Paging<T>> NextPage<T>(Paging<T> page)
    public async Task<Paging<T>> NextPage<T>(Paging<T> page)
    {
        if (page.NextHref is null)
            throw new ApiPagingException("Paging object has no next page");
        
        return _connector.GetAsync<Paging<T>>(page.NextHref);
        return await _connector.GetAsync<Paging<T>>(page.NextHref);
    }

    public async IAsyncEnumerable<T> PaginateAll<T>(Paging<T> firstPage)
    {
        if (firstPage.Collection is null)
            throw new ArgumentException("First page has no collection");

        var page = firstPage;
        foreach (var item in page.Collection)
        {
            yield return item;
        }
        while (page.NextHref is not null)
        {
            page = await _connector.GetAsync<Paging<T>>(page.NextHref);
            foreach (var item in page.Collection)
            {
                yield return item;
            }
        }
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