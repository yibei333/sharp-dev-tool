﻿using Microsoft.Extensions.Logging;
using SharpDevTool.Mobile.Services;
using SharpDevTool.Shared;

namespace SharpDevTool.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            ServiceContainer.Init(services =>
            {
                services.AddSingleton<IPlatformService, PlatformService>();
            });

            var builder = MauiApp.CreateBuilder();
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

            return builder.Build();
        }
    }
}
