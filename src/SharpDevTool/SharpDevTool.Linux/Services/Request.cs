using Microsoft.JSInterop;

namespace SharpDevTool.Linux.Services;

public class Request
{
    public IJSObjectReference? OptionInstance { get; set; }
}

public class Request<TData> : Request
{
    public TData? Data { get; set; }
}

