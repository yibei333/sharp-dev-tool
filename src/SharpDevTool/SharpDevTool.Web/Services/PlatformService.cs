using SharpDevTool.Shared;

namespace SharpDevTool.Web.Services;

internal class PlatformService : IPlatformService
{
    public string Get()
    {
        return "Web";
    }
}
