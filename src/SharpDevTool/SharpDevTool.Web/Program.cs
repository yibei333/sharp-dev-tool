using SharpDevTool.Shared;
using SharpDevTool.Web.Services;

ServiceContainer.Init(services =>
{
    services.AddSingleton<IPlatformService, PlatformService>();
});

var options = new WebApplicationOptions
{
    Args = args,
    WebRootPath = Path.Combine(AppContext.BaseDirectory, "wwwroot")
};
var builder = WebApplication.CreateBuilder(options);

var app = builder.Build();
var fileOption = new DefaultFilesOptions();
fileOption.DefaultFileNames.Clear();
fileOption.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(fileOption);
app.UseStaticFiles();
app.Run();
