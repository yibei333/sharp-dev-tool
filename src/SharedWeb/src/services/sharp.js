export class SharpService {
    razorPageLoaded = false;
    devService = new DevService();

    async ensureRazorPageLoaded() {
        if (this.razorPageLoaded) return;
        await new Promise((resolve) => {
            let timer = setInterval(async () => {
                if (document.getElementById('razor-page-loaded')) {
                    resolve();
                    clearInterval(timer);
                }
            }, 100);
        });
        this.razorPageLoaded = true;
    }

    async getPlatform() {
        await this.ensureRazorPageLoaded();
        return currentPlatform;
    }

    async invokeAsync(methodName, params) {
        await this.ensureRazorPageLoaded();
        let platform = await this.getPlatform();
        if (platform == 'dev') {
            return this.devService.invokeAsync(methodName, params);
        }

        return DotNet.invokeMethodAsync('SharpDevTool.Shared', methodName, params);
    }

    async invokeWithReferenceAsync(methodName, params) {
        await this.ensureRazorPageLoaded();
        let platform = await this.getPlatform();
        if (platform == 'dev') {
            return this.devService.invokeWithReferenceAsync(methodName, params);
        }

        let request = {
            optionInstance: DotNet.createJSObjectReference(params),
            data: params
        };
        return DotNet.invokeMethodAsync('SharpDevTool.Shared', methodName, request);
    }
}

class DevService {
    async invokeAsync(methodName, params) {
        if (methodName == 'GetMessage') {
            return `from dev:${params}`;
        } else {
            throw `${methodName} not implemented`;
        }
    }

    async invokeWithReferenceAsync(methodName, params) {
        if (methodName == 'GetOtherMessage') {
            params.test(params.message.length);
            return `from dev other:${params.message}`;
        } else {
            throw `${methodName} not implemented`;
        }
    }
}