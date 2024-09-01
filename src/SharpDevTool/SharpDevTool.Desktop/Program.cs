
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using SharpDevTool.Desktop.Components;
using SharpDevTool.Desktop.Services;
using SharpDevTool.Shared;

class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        ServiceContainer.Init(services =>
        {
            services.AddSingleton<IPlatformService, PlatformService>();
        });

        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);
        appBuilder.Services.AddLogging();
        appBuilder.RootComponents.Add<Home>("app");

        var app = appBuilder.Build();
        app.MainWindow.SetIconFile("wwwroot/favicon.ico").SetTitle("Photino Blazor Sample").SetDevToolsEnabled(true).SetContextMenuEnabled(true);
        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };
        app.Run();
    }
}