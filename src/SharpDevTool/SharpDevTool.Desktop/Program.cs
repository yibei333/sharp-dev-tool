
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
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);
        appBuilder.Services.AddSingleton<IPlatformService, PlatformService>();
        appBuilder.Services.AddLogging();
        appBuilder.RootComponents.Add<Home>("app");

        var app = appBuilder.Build();
        Services.SetProvider(app.Services);
        app.MainWindow.SetIconFile("wwwroot/favicon.ico").SetTitle("Photino Blazor Sample").SetDevToolsEnabled(true).SetContextMenuEnabled(true);
        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };
        app.Run();
    }
}