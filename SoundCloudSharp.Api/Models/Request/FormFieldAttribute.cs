namespace SoundCloudSharp.Api.Models.Request;

[AttributeUsage(AttributeTargets.Property)]
public class FormFieldAttribute : Attribute
{
    public string Name { get; set; }
    public FormFieldAttribute(string name) => Name = name;
}