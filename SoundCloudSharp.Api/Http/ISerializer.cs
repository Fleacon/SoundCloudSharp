namespace SoundCloudSharp.Api.Http;

public interface ISerializer
{
    public DeserializedResponse<T> DeserializeResponse<T>(Response response);
    public Request SerializeBody(Request request);
}