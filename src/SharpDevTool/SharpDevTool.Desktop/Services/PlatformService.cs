using SharpDevTool.Shared.Services;

namespace SharpDevTool.Desktop.Services;

internal class PlatformService : IPlatformService
{
    public string Get()
    {
        return "Desktop";
    }
}
