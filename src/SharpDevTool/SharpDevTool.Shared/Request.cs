using Microsoft.JSInterop;

namespace SharpDevTool.Shared;

public class Request
{
    public IJSObjectReference? OptionInstance { get; set; }
}

public class Request<TData> : Request
{
    public TData? Data { get; set; }
}

