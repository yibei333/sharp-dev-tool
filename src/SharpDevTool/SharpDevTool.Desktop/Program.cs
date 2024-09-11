using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using SharpDevTool.Desktop.Components;
using SharpDevTool.Desktop.Services;
using SharpDevTool.Shared;
using System.Reflection;

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
        HandleException(app);
        Services.SetProvider(app.Services);
        app.MainWindow.SetIconFile("wwwroot/favicon.ico").SetTitle(Assembly.GetExecutingAssembly().GetName().Name).SetDevToolsEnabled(true).SetContextMenuEnabled(true);
        app.MainWindow.RegisterWindowCreatedHandler((obj, args) => RemoveShortcut(app));
        app.Run();

    }

    static void RemoveShortcut(PhotinoBlazorApp app)
    {
        //var path = @"C:\Users\Devel\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\C#开发工具.lnk";
        //var isExist = File.Exists(path);
        //if (isExist) File.Delete(path);
        //app.MainWindow.ShowMessage("Fatal exception", "ok");
    }

    static void HandleException(PhotinoBlazorApp app)
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };
    }
}