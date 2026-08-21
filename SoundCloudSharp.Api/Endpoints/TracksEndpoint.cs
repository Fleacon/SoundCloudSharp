using System.Net.Http.Headers;
using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class TracksEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<Track> CreateTrackAsync(TrackDataRequest request, 
        CancellationToken cancellationToken = default)
    {
        var form = FormDataBuilder.Build(request);
        var assetFileName = Path.GetFileName(request.AssetData.Name);
        var assetFileContent = new StreamContent(request.AssetData);
        assetFileContent.Headers.ContentType = new MediaTypeHeaderValue(FileTypeUtil.GetAudioContentType(assetFileName));
        form.Add(assetFileContent, "track[asset_data]", assetFileName);

        if (request.ArtworkData is not null)
        {
            var artworkFileName = Path.GetFileName(request.ArtworkData.Name);
            var artworkFileContent = new StreamContent(request.ArtworkData);
            artworkFileContent.Headers.ContentType = new MediaTypeHeaderValue(FileTypeUtil.GetImageContentType(artworkFileName));
            form.Add(artworkFileContent, "track[artwork_data]", artworkFileName);
        }
        
        return await Connector.PostAsync<Track>(SoundCloudUrls.Tracks(), form, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<Track> GetTrackAsync(string trackUrn, string? secretToken = null, 
        CancellationToken cancellationToken = default)
    {
        var query  = BuildQuery(secretToken, "secret_token");
        return await Connector.GetAsync<Track>(SoundCloudUrls.Track(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Track> UpdateTrackAsync(string trackUrn, TrackMetadataRequest request,
        CancellationToken cancellationToken = default)
    {
        var form = FormDataBuilder.Build(request);
        if (request.ArtworkData is not null)
        {
            var fileName = Path.GetFileName(request.ArtworkData.Name);
            var fileContent = new StreamContent(request.ArtworkData);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(FileTypeUtil.GetImageContentType(fileName));
            form.Add(fileContent, "track[artwork_data]", fileName);
        }
        return await Connector.PutAsync<Track>(SoundCloudUrls.Track(trackUrn), form, cancellationToken).ConfigureAwait(false);
    }

    public async Task<bool> DeleteTrackAsync(string trackUrn, 
        CancellationToken cancellationToken = default)
    {
        var response = await Connector.DeleteAsync(SoundCloudUrls.Track(trackUrn), cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<Storefront> CreateOrUpdateStorefrontAsync(string trackUrn, StorefrontUpdateRequest request,
        CancellationToken cancellationToken = default)
    {
        return await Connector.PutAsync<Storefront>(SoundCloudUrls.TrackStorefront(trackUrn), request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<FoundResponse> StartPreviewPlaybackAsync(string trackUrn, string? secretToken = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(secretToken, "secretToken");
        return await Connector.GetAsync<FoundResponse>(SoundCloudUrls.TrackPreview(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<StreamsResponse> GetTrackSteamsAsync(string trackUrn, string? secretToken = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(secretToken, "secretToken");
        return await Connector.GetAsync<StreamsResponse>(SoundCloudUrls.TrackStreams(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Comment>> GetCommentsAsync(string trackUrn, GetTrackCommentsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Comment>>(SoundCloudUrls.TrackComments(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Comment> CreateCommentAsync(string trackUrn, CreateCommentRequest request,
        CancellationToken cancellationToken = default)
    {
        var envelope = new CreateCommentRequestEnvelope(request);
        return await Connector.PostAsync<Comment>(SoundCloudUrls.TrackComments(trackUrn), envelope, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<FullUser?>> GetTrackFavoritersAsync(string trackUrn, GetTrackFavoritersRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.TrackFavoriters(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<FullUser?>> GetTrackRepostersAsync(string trackUrn, int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit, "limit");
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.TrackReposters(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Track>> GetRelatedTracksAsync(string trackUrn, GetRelatedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.TrackRelated(trackUrn), query, cancellationToken).ConfigureAwait(false);
    }
}