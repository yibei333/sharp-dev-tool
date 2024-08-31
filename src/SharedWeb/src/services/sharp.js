export class SharpService {
    razorPageLoaded = false;

    async ensureRazorPageLoaded() {
        if (this.razorPageLoaded) return;
        await new Promise((resolve) => {
            let timer = setInterval(() => {
                if (document.getElementById('razor-page-loaded')) {
                    resolve();
                }
            }, 100);
        });
    }

    async invokeAsync(methodName, params) {
        await this.ensureRazorPageLoaded();
        return DotNet.invokeMethodAsync('SharpDevTool.Linux', methodName, params);
    }

    async invokeWithReferenceAsync(methodName, params) {
        await this.ensureRazorPageLoaded();
        let request = {
            optionInstance: DotNet.createJSObjectReference(params),
            data: params
        };
        return DotNet.invokeMethodAsync('SharpDevTool.Linux', methodName, request);
    }
}