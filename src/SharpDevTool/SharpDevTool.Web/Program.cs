using Microsoft.Extensions.Hosting.WindowsServices;
using SharpDevTool.Shared;
using SharpDevTool.Web.Services;

ServiceContainer.Init(services =>
{
    services.AddSingleton<IPlatformService, PlatformService>();
});

var options = new WebApplicationOptions
{
    Args = args,
    ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default,
    WebRootPath = Path.Combine(AppContext.BaseDirectory, "wwwroot")
};
var builder = WebApplication.CreateBuilder(options);
builder.Host.UseWindowsService();

var app = builder.Build();
var fileOption = new DefaultFilesOptions();
fileOption.DefaultFileNames.Clear();
fileOption.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(fileOption);
app.UseStaticFiles();
app.Run();
