namespace SoundCloudSharp.Api.Models.Common;

public static class Enums {
    public enum Embed
    {
        All,
        Me,
        None
    }

    public enum Sharing
    {
        Public,
        Private
    }

    public enum License
    {
        NoRightsReserved,
        AllRightReserved,
        CcBy,
        CcByNc,
        CcByNd,
        CcBySa,
        CcByNcNd,
        CcByNcSa
    }
    
    public enum PlaylistType
    {
        Album,
        Playlist
    }
    
    public enum Access
    {
        Playable,
        Preview,
        Blocked
    }

    public enum StoreType
    {
        Digital,
        Vinyl,
        Cd,
        Cassette,
        Apparel,
        SamplePack,
        Subscription,
        LiveEvent,
        LiveStream,
        Other
    }

    public enum Sort
    {
        Desc,
        Asc
    }
}