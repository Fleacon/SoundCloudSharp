using System.Runtime.Serialization;

namespace SoundCloudSharp.Api.Models.Common;

public static class Enums {
    public enum Embed
    {
        Unknown,
        All,
        Me,
        None,
    }

    public enum Sharing
    {
        Unknown,
        Public,
        Private
    }

    public enum License
    {
        Unknown,
        [EnumMember(Value = "no-rights-reserved")]
        NoRightsReserved,
        [EnumMember(Value = "all-rights-reserved")]
        AllRightsReserved,
        [EnumMember(Value = "cc-by")]
        CcBy,
        [EnumMember(Value = "cc-by-nc")]
        CcByNc,
        [EnumMember(Value = "cc-by-nd")]
        CcByNd,
        [EnumMember(Value = "cc-by-sa")]
        CcBySa,
        [EnumMember(Value = "cc-by-nc-nd")]
        CcByNcNd,
        [EnumMember(Value = "cc-by-nc-sa")]
        CcByNcSa
    }
    
    public enum PlaylistType
    {
        Unknown,
        Album,
        Playlist
    }
    
    public enum Access
    {
        Unknown,
        Playable,
        Preview,
        Blocked
    }

    public enum StoreType
    {
        Unknown,
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
        Unknown,
        Desc,
        Asc
    }
}