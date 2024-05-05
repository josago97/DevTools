using System.Text.Json.Serialization;
using DevTools.Views.Components.Split.JsonConverters;

namespace DevTools.Views.Components.Split.OptionTypes;

[JsonConverter(typeof(EnumJsonConverter))]
public enum Direction
{
    Horizontal,
    Vertical
}