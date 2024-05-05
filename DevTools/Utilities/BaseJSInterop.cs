using Microsoft.JSInterop;

namespace DevTools.Utilities;

public class BaseJSInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    protected IJSObjectReference Module { get; private set; }

    public BaseJSInterop(IJSRuntime jsRuntime, string jsPath)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", jsPath).AsTask());
    }

    protected async Task EnsureModuleLoadedAsync()
    {
        if (Module == null)
        {
            Module = await _moduleTask.Value;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            IJSObjectReference module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
