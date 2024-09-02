export class WebService {
    async invokeAsync(methodName, params) {
        if (methodName == 'GetMessage') {
            return `from dev:${params}`;
        } else {
            throw `${methodName} not implemented`;
        }
    }

    async invokeWithReferenceAsync(methodName, params) {
        if (methodName == 'GetOtherMessage') {
            params.invokeJsMethod(params.message.length);
            return `from dev other:${params.message}`;
        } else {
            throw `${methodName} not implemented`;
        }
    }
}