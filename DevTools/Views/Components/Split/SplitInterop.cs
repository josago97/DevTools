using System.Text.Json;
using System.Text.Json.Serialization;
using DevTools.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DevTools.Views.Components.Split;

public class SplitInterop : BaseJSInterop
{
    public SplitInterop(IJSRuntime jsRuntime) : base(jsRuntime, "./js/split/split-interop.js")
    {
    }

    public async Task<SplitInstance> CreateInstance(IEnumerable<ElementReference> elementReferences, SplitOptions? options = null)
    {
       await EnsureModuleLoadedAsync();

        IJSObjectReference instanceReference;
        if (options == null)
            instanceReference = await Module.InvokeAsync<IJSObjectReference>("createInstance", elementReferences);
        else
        {
            // Custom serialization to ensure we send null values as undefined and not null
            var optionsJson = JsonSerializer.SerializeToDocument(options, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
            instanceReference = await Module.InvokeAsync<IJSObjectReference>("createInstance", elementReferences, optionsJson);
        }

        return new SplitInstance(instanceReference);
    }
}