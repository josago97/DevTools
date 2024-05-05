using System.Text.Json;
using System.Text.Json.Serialization;

namespace DevTools.Views.Components.Split.JsonConverters;

public class EnumJsonConverter : JsonStringEnumConverter
{
    public EnumJsonConverter() : base(JsonNamingPolicy.CamelCase)
    {

    }
}