using System.Net.Http.Headers;
using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;
using SoundCloudSharp.Api.Exceptions;

namespace SoundCloudSharp.Api.Endpoints;

/// <summary>
/// Tracks Endpoints.
/// </summary>
public class TracksEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Uploads a new track.
    ///
    /// Corresponds to <c>POST /tracks</c>
    /// </summary>
    /// <param name="request">The track and the related properties that will be uploaded</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the uploaded track</returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiUnprocessableEntityException">The track could not be uploaded. The response message states the reason.</exception>
    public async Task<Track> CreateTrackAsync(TrackDataRequest request, 
        CancellationToken cancellationToken = default)
    {
        var form = FormDataBuilder.Build(request);
        var assetFileName = Path.GetFileName(request.AssetData.FileName);
        var assetFileContent = new StreamContent(request.AssetData.Data);
        assetFileContent.Headers.ContentType = new MediaTypeHeaderValue(FileTypeUtil.GetAudioContentType(assetFileName));
        form.Add(assetFileContent, "track[asset_data]", assetFileName);

        if (request.ArtworkData is not null)
        {
            var artworkFileName = Path.GetFileName(request.ArtworkData.FileName);
            var artworkFileContent = new StreamContent(request.ArtworkData.Data);
            artworkFileContent.Headers.ContentType = new MediaTypeHeaderValue(FileTypeUtil.GetImageContentType(artworkFileName));
            form.Add(artworkFileContent, "track[artwork_data]", artworkFileName);
        }
        
        return await Connector.PostAsync<Track>(SoundCloudUrls.Tracks(), form, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a track.
    ///
    /// Corresponds to <c>GET /tracks/{track_urn}</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track that will be returned</param>
    /// <param name="request">Optional Secret Token</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a track associated with the <paramref name="trackUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> doesn't exist</exception>
    public async Task<Track> GetTrackAsync(string trackUrn, GetTrackRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query  = BuildQuery(request);
        return await Connector.GetAsync<Track>(SoundCloudUrls.Track(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Updates a track's information.
    ///
    /// Corresponds to <c>PUT /tracks/{track_urn}</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track that will be updated</param>
    /// <param name="request">Properties/Information that will be applied to the specified tracks</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the track associated with the <paramref name="trackUrn"/> that was updated</returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    public async Task<Track> UpdateTrackAsync(string trackUrn, TrackMetadataRequest request,
        CancellationToken cancellationToken = default)
    {
        var form = FormDataBuilder.Build(request);
        if (request.ArtworkData is not null)
        {
            var fileName = Path.GetFileName(request.ArtworkData.FileName);
            var fileContent = new StreamContent(request.ArtworkData.Data);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(FileTypeUtil.GetImageContentType(fileName));
            form.Add(fileContent, "track[artwork_data]", fileName);
        }
        return await Connector.PutAsync<Track>(SoundCloudUrls.Track(trackUrn), form, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Deletes a track.
    ///
    /// Corresponds to <c>DELETE /tracks/{track_urn}</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track that will be deleted</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> doesn't exist</exception>
    public async Task DeleteTrackAsync(string trackUrn, 
        CancellationToken cancellationToken = default)
    { 
        await Connector.DeleteAsync(SoundCloudUrls.Track(trackUrn), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Creates or updates the storefront (Artist Storefront) of a track.
    ///
    /// Corresponds to <c>PUT /tracks/{track_urn}/storefront</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the tracks storefront that will be created or updated</param>
    /// <param name="request">Properties/Information which will applied to the newly created storefront or updated on an existing storefront</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <remarks>Creates or updates the storefront module shown on the track page. The request replaces the whole storefront: optional fields (link_title, description, price) are cleared when omitted, so always send every value the storefront should keep. The request fails with 403 when the authenticated user does not own the track, and also when the user does not hold a creator subscription that includes external purchase options. The storefront links to an external page — no payment is processed by SoundCloud.</remarks>
    /// <returns>A task that represents the asynchronous operation. The task result contains the storefront associated with the <paramref name="trackUrn"/></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiForbiddenException">The authenticated user doesn't own the track or does not hold a creator subscription with external purchase options</exception>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> doesn't exist</exception>
    public async Task<Storefront> CreateOrUpdateStorefrontAsync(string trackUrn, StorefrontUpdateRequest request,
        CancellationToken cancellationToken = default)
    {
        return await Connector.PutAsync<Storefront>(SoundCloudUrls.TrackStorefront(trackUrn), request, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Starts playback of a preview of the track
    ///
    /// Corresponds to <c>GET /tracks/{track_urn}/preview</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track which preview playback will be started</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException"></exception>
    public async Task<FoundResponse> StartPreviewPlaybackAsync(string trackUrn, StartTrackPreviewPlaybackRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<FoundResponse>(SoundCloudUrls.TrackPreview(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a track's streamable URLs
    ///
    /// Corresponds to <c>GET /tracks/{track_urn}/streams</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track which streamable url will be returned</param>
    /// <param name="request">Optional Secret Token</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <remarks>needs to keep using authentication</remarks>
    /// <returns>A task that represents the asynchronous operation. The task result contains the URL of the resource</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> does not exist</exception>
    public async Task<StreamsResponse> GetTrackStreamsAsync(string trackUrn, GetTrackStreamsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<StreamsResponse>(SoundCloudUrls.TrackStreams(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the comments posted on the track(track_urn).
    ///
    /// Corresponds to <c>GET /tracks/{track_urn}/comments</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track which comments will be returned</param>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of comments from the track associated with the <paramref name="trackUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> doesn't exist</exception>
    public async Task<Paging<Comment>> GetCommentsAsync(string trackUrn, GetTrackCommentsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Comment>>(SoundCloudUrls.TrackComments(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the newly created comment on success
    ///
    /// Corresponds to <c>POST /tracks/{track_urn}/comments</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track where the comment will be posted</param>
    /// <param name="request">Body of a comment</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the newly created comment</returns>
    /// <exception cref="ApiUnprocessableEntityException">The comment could not be created. The response message states the reason.</exception>
    /// <exception cref="ApiTooManyRequestsException">The request exceeds a SoundCloud API rate limit</exception>
    public async Task<Comment> CreateCommentAsync(string trackUrn, CreateCommentRequest request,
        CancellationToken cancellationToken = default)
    {
        var envelope = new CreateCommentRequestEnvelope(request);
        return await Connector.PostAsync<Comment>(SoundCloudUrls.TrackComments(trackUrn), envelope, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of users Who have favorited or liked the track.
    ///
    /// Corresponds to <c>GET /tracks/{track_urn}/favoriters</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track which users that favorited or liked will be returned</param>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of users that favorited or liked the track associated with the <paramref name="trackUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> does not exist</exception>
    public async Task<Paging<FullUser?>> GetTrackFavoritersAsync(string trackUrn, GetTrackFavoritersRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.TrackFavoriters(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a collection of track's reposters.
    ///
    /// Corresponds to <c>GET /tracks/{track_urn}/reposters</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track which user have reposted it will be returned</param>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of who reposted the track associated with the <paramref name="trackUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> does not exist</exception>
    public async Task<Paging<FullUser?>> GetTrackRepostersAsync(string trackUrn, GetTrackRepostersRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.TrackReposters(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns all related tracks of track on SoundCloud.
    ///
    /// Corresponds to <c>GET /tracks/{track_urn}/related</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track which related tracks will be returned</param>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException"></exception>
    public async Task<Paging<Track>> GetRelatedTracksAsync(string trackUrn, GetRelatedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.TrackRelated(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }
}