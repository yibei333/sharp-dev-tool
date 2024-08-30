using ElectronNET.API;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseElectron(args);
builder.Services.AddElectron();
builder.Services.AddRazorComponents();

var app = builder.Build();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<SharpDevTool.Linux.Home>();
await app.StartAsync();
await Electron.WindowManager.CreateWindowAsync();
Electron.WindowManager.BrowserWindows.FirstOrDefault()?.RemoveMenu();
app.WaitForShutdown();