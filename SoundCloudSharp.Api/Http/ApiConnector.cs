using System.Net;
using SoundCloudSharp.Api.Authenticators;
using SoundCloudSharp.Api.Exceptions;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Http;

public class ApiConnector
{
    private readonly HttpService _httpClient;
    private readonly JsonSerializer _serializer;
    private readonly IAuthenticator? _authenticator;

    public ApiConnector()
    {
        _httpClient = new ();
        _serializer = new ();
    }

    public ApiConnector(IAuthenticator authenticator)
    {
        _httpClient = new ();
        _serializer = new ();
        _authenticator = authenticator;
    }
    
    public async Task<T> GetAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<T> GetAsync<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Get, parameters: parameters,  cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<HttpStatusCode> DeleteAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoRawRequest(uri, HttpMethod.Delete, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response.StatusCode;
    }

    public async Task<T> PutAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Put, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<T> PutAsync<T>(Uri uri, object? body, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Put, body: body, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }
    
    public async Task<HttpStatusCode> PutAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoRawRequest(uri, HttpMethod.Put, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response.StatusCode;
    }

    public async Task<T> PostAsync<T>(Uri uri, object? body, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Post, body: body, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<HttpStatusCode> PostAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoRawRequest(uri, HttpMethod.Post, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response.StatusCode;
    }

    public async Task<T> AuthPostAsync<T>(Uri baseUri, object body, IDictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(null, HttpMethod.Post, headers: headers, body: body, baseUri: baseUri, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    private Request BuildRequest(Uri? uri, HttpMethod method, IDictionary<string, string>? parameters, IDictionary<string, string>? headers, object? body)
    {
        var request = new Request(uri, method)
        {
            Headers = headers ?? new Dictionary<string, string>(),
            Body = body,
            Parameters = parameters ?? new Dictionary<string, string>(),
        };
        _authenticator?.Apply(request, this);
        var serializedRequest = _serializer.SerializeBody(request);
        return serializedRequest;
    }

    // TODO: Process Errors
    
    private async Task<T> DoSerializedRequest<T>(Uri? uri, HttpMethod method, 
        IDictionary<string, string>? parameters = null, IDictionary<string, string>? headers = null, 
        object? body = null, Uri? baseUri = null, CancellationToken cancellationToken = default)
    {
        baseUri ??= SoundCloudUrls.BaseUri;
        var request = BuildRequest(uri, method, parameters, headers, body);
        var rawResponse = await _httpClient.DoRequest(baseUri, request, cancellationToken).ConfigureAwait(false);
        ProcessErrors(rawResponse);
        var deserializedResponse = _serializer.DeserializeResponse<T>(rawResponse);
        return deserializedResponse.Content!;
    }

    private async Task<Response> DoRawRequest(Uri uri, HttpMethod method,
        IDictionary<string, string>? parameters = null, IDictionary<string, string>? headers = null,
        object? body = null, Uri? baseUri = null, CancellationToken cancellationToken = default)
    {
        baseUri ??= SoundCloudUrls.BaseUri;
        var request = BuildRequest(uri, method, parameters, headers, body);
        return await _httpClient.DoRequest(baseUri, request, cancellationToken).ConfigureAwait(false);
    }

    private void ProcessErrors(Response response)
    {
        if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 400)
        {
            return;
        }

        throw response.StatusCode switch
        {
            HttpStatusCode.Unauthorized => new ApiUnauthorizedException(SerializeError<ErrorResponse>(response)),
            HttpStatusCode.TooManyRequests => new ApiTooManyRequestsException(SerializeError<TooManyRequestsResponse>(response)),
            HttpStatusCode.BadRequest => new ApiBadRequestException(SerializeError<ErrorResponse>(response)),
            HttpStatusCode.Forbidden => new ApiForbiddenException(SerializeError<ErrorResponse>(response)),
            HttpStatusCode.NotFound => new ApiNotFoundExcpetion(SerializeError<ErrorResponse>(response)),
            _ => new ApiException(SerializeError<ErrorResponse>(response))
        };
    }

    private T SerializeError<T>(Response response) => _serializer.DeserializeResponse<T>(response).Content!;
}