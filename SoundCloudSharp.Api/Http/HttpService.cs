using System.Text;

namespace SoundCloudSharp.Api.Http;

public class HttpService : IDisposable
{
    private readonly HttpClient _httpClient;

    public HttpService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<Response> DoRequestAsync(Uri baseAddress, Request request, CancellationToken cancellationToken = default)
    {
        var httpRequestMessage = CreateRequest(baseAddress, request);
        var httpResponse = await _httpClient.SendAsync(httpRequestMessage,  cancellationToken).ConfigureAwait(false);
        var response = await CreateResponseAsync(httpResponse, cancellationToken).ConfigureAwait(false);
        return response;
    }

    private static HttpRequestMessage CreateRequest(Uri baseAddress, Request request)
    {
        var absoluteUri = baseAddress;
        if (request.Endpoint is not null)
            absoluteUri = new Uri(baseAddress, request.Endpoint);
        var fullUri = BuildUriWithQuery(absoluteUri, request.Parameters);
        var requestMessage = new HttpRequestMessage(request.Method, fullUri);
        foreach (var header in request.Headers)
        {
            requestMessage.Headers.Add(header.Key, header.Value);
        }

        requestMessage.Content = request.Body switch
        {
            HttpContent body => body,
            string body => new StringContent(body, Encoding.UTF8, "application/json"),
            Stream body => new StreamContent(body),
            _ => requestMessage.Content
        };
        
        return requestMessage;
    }
    
    private static Uri BuildUriWithQuery(Uri endpoint, IDictionary<string, string> query)
    {
        if (query.Count == 0)
            return endpoint;

        var queryString = string.Join("&",
            query.Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));

        return new Uri($"{endpoint}?{queryString}", UriKind.Absolute);
    }

    private static async Task<Response> CreateResponseAsync(HttpResponseMessage httpResponse,  CancellationToken cancellationToken = default)
    {
        var body = await httpResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var headers = httpResponse.Headers.ToDictionary(header => header.Key, header => header.Value.First());
        return new Response(httpResponse.StatusCode, headers)
        {
            Body = body,
            ContentType = httpResponse.Content.Headers.ContentType?.MediaType
        };
    }

    public void Dispose()
    {
        _httpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}