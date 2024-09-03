using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace SharpDevTool.Shared;

public static class Services
{
    static IServiceProvider? _serviceProvider;

    static IServiceProvider ServiceProvider => _serviceProvider ?? throw new Exception("please call SharpDevTool.Shared.Services.SetProvider method");

    public static void SetProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

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
            await request.OptionInstance.InvokeVoidAsync("invokeJsMethod", request.Data?.Message?.Length ?? 0);
        }
        var platformService = ServiceProvider.GetRequiredService<IPlatformService>();
        return $"ok,{platformService.Get()},{request.Data?.Message}";
    }
}

public class GetOtherMessageModel
{
    public string? Message { get; set; }
}