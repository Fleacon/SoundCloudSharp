# SoundCloudSharp

A complete & fully-typed SoundCloud API Wrapper for .NET.

## Features

- Strongly typed models for SoundCloud resources
- Every non-deprecated endpoint
- Asynchronous Requests
- Support for OAuth 2.1 authentication (Authorization Code & Client Credentials flow)
- Pagination with helper methods
- Custom Exceptions
- Automatically refresh access token

## Installation

```

```

## Usage

SoundCloud requires authentication to use their endpoints.

```csharp
var client = new SoundCloudClient(ACCESS_TOKEN);

var search = new SearchTracksRequest
{
    Query = "Never Gonna Give You Up"
};

var tracks = await client.Search.SearchTracksAsync(search);

foreach (var track in tracks.Collection)
{
    Console.WriteLine(track.Title);
}
```

## Docs & Usage

## Contributing
