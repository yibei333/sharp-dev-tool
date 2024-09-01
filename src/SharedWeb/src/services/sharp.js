export class SharpService {
    razorPageLoaded = false;

    async ensureRazorPageLoaded() {
        if (this.razorPageLoaded) return;
        await new Promise((resolve) => {
            let count = 1;
            let timer = setInterval(() => {
                if (document.getElementById('razor-page-loaded')) {
                    resolve();
                    clearInterval(timer);
                }
                if (count > 5) {
                    try {
                        Blazor.start();
                    } catch (e) {
                        console.log(1, e);
                    }
                }
                count++;
            }, 100);
        });
        this.razorPageLoaded = true;
    }

    async invokeAsync(methodName, params) {
        await this.ensureRazorPageLoaded();
        return DotNet.invokeMethodAsync('SharpDevTool.Shared', methodName, params);
    }

    async invokeWithReferenceAsync(methodName, params) {
        await this.ensureRazorPageLoaded();
        let request = {
            optionInstance: DotNet.createJSObjectReference(params),
            data: params
        };
        return DotNet.invokeMethodAsync('SharpDevTool.Shared', methodName, request);
    }
}