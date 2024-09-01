using Microsoft.Extensions.DependencyInjection;

namespace SharpDevTool.Shared.Services;

public static class ServiceContainer
{
    static IServiceProvider? _serviceProvider;

    public static IServiceProvider ServiceProvider => _serviceProvider ?? throw new Exception("please call ServiceContainer.Init method");

    public static void Init(Action<IServiceCollection> serviceAction)
    {
        IServiceCollection services = new ServiceCollection();
        serviceAction(services);
        _serviceProvider = services.BuildServiceProvider();
    }
}
