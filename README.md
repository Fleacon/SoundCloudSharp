# SoundCloudSharp

[![License](https://img.shields.io/github/license/Fleacon/SoundCloudSharp)](./LICENSE)
[![SoundCloudSharp.Api NuGET](https://img.shields.io/nuget/vpre/SoundCloudSharp.Api)](https://www.nuget.org/packages/SoundCloudSharp.Api)

A complete & fully-typed SoundCloud API Wrapper for .NET.

## Features

- Strongly typed models for SoundCloud responses
- Async API calls
- OAuth flow with PKCE
- Pagination helpers
- Easy access to tracks, users, playlists, likes, reposts, and more
- Custom exceptions for API errors
- Built for .NET apps and services

## Installation

Install the package using the .NET CLI:

```bash
dotnet add package SoundCloudSharp.Api
```

Or add it directly to your project file:

```xml
<ItemGroup>
  <PackageReference Include="SoundCloudSharp.Api" Version="1.0.0" />
</ItemGroup>
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

## Docs & Usage

## Contributing

## Acknowledgements

SoundCloudSharp was strongly inspired by
[SpotifyAPI-NET](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master).

Its API design and developer experience informed parts of this project.
SoundCloudSharp is an independent implementation and is not affiliated with, endorsed by, or maintained by the original project or SoundCloud.
