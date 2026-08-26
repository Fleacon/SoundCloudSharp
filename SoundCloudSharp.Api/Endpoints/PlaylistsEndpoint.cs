using System.Net.Http.Headers;
using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;
using SoundCloudSharp.Api.Exceptions;

namespace SoundCloudSharp.Api.Endpoints;

/// <summary>
/// Playlists Endpoints.
/// </summary>
public class PlaylistsEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Creates a playlist.
    /// 
    /// Corresponds to <c>POST /playlists</c>
    /// </summary>
    /// <param name="request">Properties about the playlist that's being created</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the newly created playlist</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException"></exception>
    public async Task<Playlist> CreatePlaylistAsync(CreatePlaylistRequest request, CancellationToken cancellationToken = default)
    {
        var form = FormDataBuilder.Build(request);
        if (request.ArtworkData is not null)
        {
            var fileName = Path.GetFileName(request.ArtworkData.FileName);
            var fileContent = new StreamContent(request.ArtworkData.Data);
            
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(FileTypeUtil.GetImageContentType(fileName));
            form.Add(fileContent, "playlist[artwork_data]", fileName);
        }
        
        return await Connector.PostAsync<Playlist>(SoundCloudUrls.Playlists(), form, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a playlist.
    /// 
    /// Corresponds to <c>GET /playlists/{playlist_urn}</c>
    /// </summary>
    /// <param name="playlistUrn">Urn of the playlist which will be returned</param>
    /// <param name="request">Optional filters and secret token.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a playlist associated with the specified <paramref name="playlistUrn"/></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    public async Task<Playlist> GetPlaylistAsync(string playlistUrn, GetPlaylistsRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Playlist>(SoundCloudUrls.Playlist(playlistUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Updates a playlist.
    ///
    /// Corresponds to <c>PUT /playlists/{playlist_urn}</c>
    /// </summary>
    /// <param name="playlistUrn">Urn of the playlist which will be updated</param>
    /// <param name="request">Properties/Information that will be applied to the specified playlist</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated playlist</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The playlist associated with the <paramref name="playlistUrn"/> does not exist</exception>
    public async Task<Playlist> UpdatePlaylistAsync(string playlistUrn, UpdatePlaylistRequest request, CancellationToken cancellationToken = default)
    {
        var envelope = new UpdatePlaylistRequestEnvelope(request);
        return await Connector.PutAsync<Playlist>(SoundCloudUrls.Playlist(playlistUrn), envelope, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Deletes a playlist.
    ///
    /// Corresponds to <c>DELETE /playlists/{playlist_urn}</c>
    /// </summary>
    /// <param name="playlistUrn">Urn of the playlist which will be deleted</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiNotFoundException">The playlist associated with the <paramref name="playlistUrn"/> does not exist</exception>
    public async Task DeletePlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var uri = SoundCloudUrls.Playlist(playlistUrn); 
        await Connector.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Returns tracks under a playlist.
    ///
    /// Corresponds to <c>GET /playlists/{playlist_urn}/tracks</c>
    /// </summary>
    /// <param name="playlistUrn">Urn of the playlist which tracks will be returned</param>
    /// <param name="request">Optional filters and secret token.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of tracks in the playlist associated with the <paramref name="playlistUrn"/></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    public async Task<Paging<Track>> GetPlaylistTracksAsync(string playlistUrn, GetPlaylistTracksRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.PlaylistTracks(playlistUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a collection of playlist's reposters.
    ///
    /// Corresponds to <c>GET /playlists/{playlist_urn}/reposters</c>
    /// </summary>
    /// <param name="playlistUrn">Urn of the playlist that users have reposted</param>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of users who reposted the playlist associated with the <paramref name="playlistUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The playlist associated with the <paramref name="playlistUrn"/> does not exist</exception>
    public async Task<Paging<FullUser>> GetPlaylistRepostersAsync(string playlistUrn, GetPlaylistRepostersRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser>>(SoundCloudUrls.PlaylistReposters(playlistUrn), query, cancellationToken).ConfigureAwait(false);
    }
}
    
    