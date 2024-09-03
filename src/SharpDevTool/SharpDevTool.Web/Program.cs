using SharpDevTool.Shared;
using SharpDevTool.Web.Services;

var options = new WebApplicationOptions
{
    Args = args,
    WebRootPath = Path.Combine(AppContext.BaseDirectory, "wwwroot")
};
var builder = WebApplication.CreateBuilder(options);
builder.Services.AddSingleton<IPlatformService, PlatformService>();

var app = builder.Build();
Services.SetProvider(app.Services);
var fileOption = new DefaultFilesOptions();
fileOption.DefaultFileNames.Clear();
fileOption.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(fileOption);
app.UseStaticFiles();
app.Run();
