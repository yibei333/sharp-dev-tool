export class SharpService {
    async invokeAsync(methodName, params) {
        return DotNet.invokeMethodAsync('SharpDevTool.Shared', methodName, params);
    }

    async invokeWithReferenceAsync(methodName, params) {
        let request = {
            optionInstance: DotNet.createJSObjectReference(params),
            data: params
        };
        return DotNet.invokeMethodAsync('SharpDevTool.Shared', methodName, request);
    }
}