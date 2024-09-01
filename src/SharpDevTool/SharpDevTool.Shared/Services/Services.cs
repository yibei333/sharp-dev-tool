using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace SharpDevTool.Shared.Services;

public static class Services
{
    [JSInvokable]
    public static async Task<string> GetMessage(string text)
    {
        await Task.Yield();
        return $"ok,{text}";
    }

    [JSInvokable]
    public static async Task<string> GetOtherMessage(Request<GetOtherMessageModel> request)
    {
        if (request.OptionInstance is not null)
        {
            await request.OptionInstance.InvokeVoidAsync("test", request.Data?.Message?.Length ?? 0);
        }
        var platformService = ServiceContainer.ServiceProvider.GetRequiredService<IPlatformService>();
        return $"ok,{platformService.Get()},{request.Data?.Message}";
    }
}

public class GetOtherMessageModel
{
    public string? Message { get; set; }
}