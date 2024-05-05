using DevTools.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DevTools.Views.Components.Dialog;

public class DialogInterop : BaseJSInterop
{
    public DialogInterop(IJSRuntime jsRuntime) : base(jsRuntime, "./js/dialog/dialog-interop.js")
    {
    }

    public async Task AddCloseEventListener(ElementReference dialog, DotNetObjectReference<Dialog> dotnet)
    {
        await EnsureModuleLoadedAsync();
        await Module.InvokeVoidAsync("addCloseEventListener", dialog, dotnet);
    }

    public async Task ShowDialogAsync(ElementReference dialog)
    {
        await EnsureModuleLoadedAsync();
        await Module.InvokeVoidAsync("showDialog", dialog);
    }

    public async Task CloseDialogAsync(ElementReference dialog)
    {
        await EnsureModuleLoadedAsync();
        await Module.InvokeVoidAsync("closeDialog", dialog);
    }
}
