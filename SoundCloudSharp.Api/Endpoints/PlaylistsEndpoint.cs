using System.Net.Http.Headers;
using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class PlaylistsEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<Playlist> CreatePlaylistAsync(CreatePlaylistRequest request, CancellationToken cancellationToken = default)
    {
        var form = FormDataBuilder.Build(request);
        if (request.ArtworkData is not null)
        {
            var fileName = Path.GetFileName(request.ArtworkData.Name);
            var fileContent = new StreamContent(request.ArtworkData);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(FileTypeUtil.GetImageContentType(fileName));
            form.Add(fileContent, "playlist[artwork_data]", fileName);
        }
        
        return await Connector.PostAsync<Playlist>(SoundCloudUrls.Playlists(), request, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<Playlist> GetPlaylistAsync(string playlistUrn, GetPlaylistsRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Playlist>(SoundCloudUrls.Playlist(playlistUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Playlist> UpdatePlaylistAsync(string playlistUrn, UpdatePlaylistRequest request, CancellationToken cancellationToken = default)
    {
        var envelope = new UpdatePlaylistRequestEnvelope(request);
        return await Connector.PutAsync<Playlist>(SoundCloudUrls.Playlist(playlistUrn), envelope, cancellationToken).ConfigureAwait(false);
    }

    public async Task<bool> DeletePlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var uri = SoundCloudUrls.Playlist(playlistUrn);
        var response = await Connector.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<Paging<Track>> GetPlaylistTracksAsync(string playlistUrn, GetPlaylistTracksRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.PlaylistTracks(playlistUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<FullUser>> GetPlaylistRepostersAsync(string playlistUrn, int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit, "limit");
        return await Connector.GetAsync<Paging<FullUser>>(SoundCloudUrls.PlaylistReposters(playlistUrn), query, cancellationToken).ConfigureAwait(false);
    }
}
    
    