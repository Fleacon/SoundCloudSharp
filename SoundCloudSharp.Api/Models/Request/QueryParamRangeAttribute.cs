namespace SoundCloudSharp.Api.Models.Request;

[AttributeUsage(AttributeTargets.Property)]
public class QueryParamRangeAttribute : Attribute
{
    public string Name { get; }
    public QueryParamRangeAttribute(string name) =>  Name = name;
}