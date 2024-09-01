using SharpDevTool.Shared;

namespace SharpDevTool.Mobile.Services;

internal class PlatformService : IPlatformService
{
    public string Get()
    {
        return "Mobile";
    }
}
