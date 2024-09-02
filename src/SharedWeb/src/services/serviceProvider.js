import { SharpService } from "./sharpService";
import { WebService } from "./webService";

export class ServiceProvider {
    razorPageLoaded = false;
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

    async getService(){
        let platform=await this.getPlatform();
        if(platform=='web') return new WebService();
        else return new SharpService();
    }
}