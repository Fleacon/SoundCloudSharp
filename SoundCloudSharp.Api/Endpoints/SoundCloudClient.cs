using SoundCloudSharp.Api.Authenticators;
using SoundCloudSharp.Api.Exceptions;
using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Auth;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Endpoints;

public class SoundCloudClient
{
    public OAuthEndpoint OAuth { get; private set; }
    public MeEndpoint Me { get; }
    public SearchEndpoint Search { get; }
    public PlaylistsEndpoint Playlists { get; }
    public TracksEndpoint Tracks { get; }
    public UsersEndpoint Users { get; }
    public LikesEndpoint Likes { get; }
    public RepostsEndpoint Reposts { get; }
    public MiscellaneousEndpoint Miscellaneous { get; }
    public DefaultEndpoint Default { get; }
    
    private readonly ApiConnector _connector;
    
    public SoundCloudClient(SoundCloudConfig config)
    {
        _connector = new ApiConnector(config);
        
        Me = new(_connector);
        Search = new(_connector);
        Playlists = new(_connector);
        Tracks = new(_connector);
        Users = new(_connector);
        Likes = new(_connector);
        Reposts = new(_connector);
        Miscellaneous = new(_connector);
        Default = new(_connector);
    }

    public SoundCloudClient(string accessToken) : this(SoundCloudConfig.CreateDefault(new StaticTokenAuthenticator(accessToken)))
    {
    }
    
    public async Task<Paging<T>> NextPageAsync<T>(Paging<T> page)
    {
        if (page.NextHref is null)
            throw new ApiPagingException("Paging object has no next page");
        
        return await _connector.GetAsync<Paging<T>>(page.NextHref).ConfigureAwait(false);
    }

    public async IAsyncEnumerable<T> PaginateAllAsync<T>(Paging<T> firstPage)
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
            page = await _connector.GetAsync<Paging<T>>(page.NextHref).ConfigureAwait(false);
            foreach (var item in page.Collection)
            {
                yield return item;
            }
        }
    }
}