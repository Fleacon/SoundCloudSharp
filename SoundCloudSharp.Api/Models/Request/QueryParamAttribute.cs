namespace SoundCloudSharp.Api.Models.Request;

[AttributeUsage(AttributeTargets.Property)]
public class QueryParamAttribute : Attribute
{
    public string Name { get; init; }
    
    public QueryParamAttribute(string name) =>  Name = name;
}