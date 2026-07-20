using System.Net;
using System.Text.Json;
using Newtonsoft.Json;
using SoundCloudSharp.Api.Endpoints;

namespace SoundCloudSharp.Api.Http;

public class ApiConnector
{
    private readonly HttpService _httpClient;
    private readonly JsonSerializer _serializer;

    public ApiConnector()
    {
        _httpClient = new ();
        _serializer = new ();
    }
    
    public async Task<T> GetAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Get, cancellationToken: cancellationToken);
        return response;
    }

    public async Task<T> GetAsync<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Get, parameters: parameters,  cancellationToken: cancellationToken);
        return response;
    }

    public async Task<HttpStatusCode> DeleteAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoRawRequest(uri, HttpMethod.Delete, cancellationToken: cancellationToken);
        return response.StatusCode;
    }

    public async Task<T> PutAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Put, cancellationToken: cancellationToken);
        return response;
    }

    public async Task<T> PutAsync<T>(Uri uri, object? body, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Put, body: body, cancellationToken: cancellationToken);
        return response;
    }
    
    public async Task<HttpStatusCode> PutAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoRawRequest(uri, HttpMethod.Put, cancellationToken: cancellationToken);
        return response.StatusCode;
    }

    public async Task<T> PostAsync<T>(Uri uri, object? body, CancellationToken cancellationToken = default)
    {
        var response = await DoSerializedRequest<T>(uri, HttpMethod.Post, body: body, cancellationToken: cancellationToken);
        return response;
    }

    public async Task<HttpStatusCode> PostAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await DoRawRequest(uri, HttpMethod.Post, cancellationToken: cancellationToken);
        return response.StatusCode;
    }

    private Request BuildRequest(Uri uri, HttpMethod method, IDictionary<string, string>? parameters, IDictionary<string, string>? headers, object? body)
    {
        var request = new Request(uri, method)
        {
            Headers = headers ?? new Dictionary<string, string>(),
            Body = body,
            Parameters = parameters ?? new Dictionary<string, string>(),
        };
        var serializedRequest = _serializer.SerializeBody(request);
        return serializedRequest;
    }

    // TODO: Process Errors
    // TODO: Apply Authentication
    
    private async Task<T> DoSerializedRequest<T>(Uri uri, HttpMethod method, 
        IDictionary<string, string>? parameters = null, IDictionary<string, string>? headers = null, 
        object? body = null, CancellationToken cancellationToken = default)
    {
        var request = BuildRequest(uri, method, parameters, headers, body);
        var rawResponse = await _httpClient.DoRequest(SoundCloudUrls.BaseUri, request, cancellationToken);
        var deserializedResponse = _serializer.DeserializeResponse<T>(rawResponse);
        return deserializedResponse.Content!;
    }

    private async Task<Response> DoRawRequest(Uri uri, HttpMethod method,
        IDictionary<string, string>? parameters = null, IDictionary<string, string>? headers = null,
        object? body = null, CancellationToken cancellationToken = default)
    {
        var request = BuildRequest(uri, method, parameters, headers, body);
        return await _httpClient.DoRequest(SoundCloudUrls.BaseUri, request, cancellationToken);
    }
}