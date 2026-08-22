using System.Net;
using SoundCloudSharp.Api.Authenticators;
using SoundCloudSharp.Api.Endpoints;
using SoundCloudSharp.Api.Exceptions;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Http;

public class ApiConnector(SoundCloudConfig config)
{
    private readonly HttpService _httpService = config.HttpService;
    private readonly ISerializer _serializer = config.Serializer;
    private readonly IAuthenticator? _authenticator = config.Authenticator;

    public async Task<T> GetAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequestAsync<T>(uri, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<T> GetAsync<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequestAsync<T>(uri, HttpMethod.Get, parameters: parameters,  cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<HttpStatusCode> DeleteAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoRawRequestAsync(uri, HttpMethod.Delete, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response.StatusCode;
    }

    public async Task<T> PutAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequestAsync<T>(uri, HttpMethod.Put, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<T> PutAsync<T>(Uri uri, object? body, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequestAsync<T>(uri, HttpMethod.Put, body: body, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }
    
    public async Task<Response> PutAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoRawRequestAsync(uri, HttpMethod.Put, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<T> PostAsync<T>(Uri uri, object? body, Uri? baseUri = null, IDictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequestAsync<T>(uri, HttpMethod.Post, headers: headers, baseUri: baseUri, body: body, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<HttpStatusCode> PostAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoRawRequestAsync(uri, HttpMethod.Post, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response.StatusCode;
    } 

    private async Task<Request> BuildRequestAsync(Uri? uri, HttpMethod method, IDictionary<string, string>? parameters, IDictionary<string, string>? headers, object? body)
    {
        var request = new Request(uri, method)
        {
            Headers = headers ?? new Dictionary<string, string>(),
            Body = body,
            Parameters = parameters ?? new Dictionary<string, string>(),
        };
        if (_authenticator is not null)
        {
            await _authenticator.Apply(request, this);
        }
        var serializedRequest = _serializer.SerializeBody(request);
        return serializedRequest;
    }
    
    private async Task<T> DoSerializedRequestAsync<T>(Uri? uri, HttpMethod method, 
        IDictionary<string, string>? parameters = null, IDictionary<string, string>? headers = null, 
        object? body = null, Uri? baseUri = null, CancellationToken cancellationToken = default)
    {
        baseUri ??= SoundCloudUrls.BaseUri;
        var request = await BuildRequestAsync(uri, method, parameters, headers, body);
        var rawResponse = await _httpService.DoRequestAsync(baseUri, request, cancellationToken).ConfigureAwait(false);
        ProcessErrors(rawResponse);
        var deserializedResponse = _serializer.DeserializeResponse<T>(rawResponse);
        return deserializedResponse.Content ?? throw new ApiFailedSerializationException(rawResponse, "Failed to deserialize request");
    }

    private async Task<Response> DoRawRequestAsync(Uri uri, HttpMethod method,
        IDictionary<string, string>? parameters = null, IDictionary<string, string>? headers = null,
        object? body = null, Uri? baseUri = null, CancellationToken cancellationToken = default)
    {
        baseUri ??= SoundCloudUrls.BaseUri;
        var request = await BuildRequestAsync(uri, method, parameters, headers, body);
        return await _httpService.DoRequestAsync(baseUri, request, cancellationToken).ConfigureAwait(false);
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
            HttpStatusCode.NotFound => new ApiNotFoundException(SerializeError<ErrorResponse>(response)),
            HttpStatusCode.UnprocessableEntity => new ApiUnprocessableEntityException(SerializeError<ErrorResponse>(response)),
            HttpStatusCode.InternalServerError => new ApiInternalServerErrorException("SoundCloud returned an internal server error (500)"),
            _ => new ApiException(SerializeError<ErrorResponse>(response))
        };
    }

    private T SerializeError<T>(Response response)
    {
        var resp = _serializer.DeserializeResponse<T>(response).Content;
        return resp ?? throw new ApiFailedSerializationException(response, $"Code: {response.StatusCode} Raw Body: {response.Body}");
    }
}