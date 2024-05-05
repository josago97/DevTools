using System.Text.Json.Serialization;
using DevTools.Views.Components.Split.JsonConverters;

namespace DevTools.Views.Components.Split.OptionTypes;

[JsonConverter(typeof(EnumJsonConverter))]
public enum GutterAlign
{
    /// <summary>
    /// Shrinks the first element to fit the gutter
    /// </summary>
    Start,

    /// <summary>
    /// Shrinks both elements by the same amount so the gutter sits between
    /// </summary>
    Center,

    /// <summary>
    /// Shrinks the second element to fit the gutter
    /// </summary>
    End
}