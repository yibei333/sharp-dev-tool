
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using SharpDevTool.Linux;

class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

        appBuilder.Services
            .AddLogging();

        // register root component and selector
        appBuilder.RootComponents.Add<Home>("app");

        var app = appBuilder.Build();

        // customize window
        app.MainWindow
            .SetIconFile("wwwroot/favicon.ico")
            .SetTitle("Photino Blazor Sample");

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };

        app.Run();
    }
}