using Microsoft.Extensions.Logging;
using SharpDevTool.Mobile.Services;
using SharpDevTool.Shared;

namespace SharpDevTool.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<IPlatformService, PlatformService>();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            SharpDevTool.Shared.Services.SetProvider(app.Services);
            return app;
        }
    }
}
