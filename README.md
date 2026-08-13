# SoundCloudSharp

A complete & fully-typed SoundCloud API Wrapper for .NET.

## Features

- Strongly typed models for SoundCloud responses
- Async API calls
- OAuth 2.1 support
- Pagination helpers
- Easy access to tracks, users, playlists, likes, reposts, and more
- Custom exceptions for API errors
- Built for .NET apps and services

## Installation

```

```

## Usage

```csharp
var client = new SoundCloudClient("YOUR_ACCESS_TOKEN");

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

### Authentication

SoundCloud requires authentication for most endpoints.

You can use either: a static **access token** or a full OAuth flow with **client credentials** / **authorization code**

Example with a static **access token**:

```csharp
var client = new SoundCloudClient("YOUR_ACCESS_TOKEN");
```

Example with **client credentials**

```csharp
var authClient = new SoundCloudClient();

var secrets = new ClientSecrets("CLIENT_ID", "CLIENT_SECRET");

var oAuthToken = await client.OAuth.RequestToken(secrets);

var client = new SoundCloudClient(
    secrets,
    oAuthToken
    );
```

## Docs & Usage

## Contributing

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/Fleacon/SoundCloudSharp/blob/master/LICENSE) file for details.
