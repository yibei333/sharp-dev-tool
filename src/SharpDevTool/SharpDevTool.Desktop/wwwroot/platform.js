let currentPlatform = 'desktop';

let blazorScript = document.createElement('script');
blazorScript.src = '_framework/blazor.webview.js';
//blazorScript.setAttribute('autostart',false);
document.body.appendChild(blazorScript);

