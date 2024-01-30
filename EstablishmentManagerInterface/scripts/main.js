const { app, BrowserWindow } = require("electron");
const API = require("./API.js");
const loginPagePath = "./pages/login/login.html";

function createWindow (pathHtmlPage){
    const window = new BrowserWindow({
        width: 1000,
        height: 800,
        webPreferences: {
            nodeIntegration: true,
            contextIsolation: false,
        }
    });
    window.loadFile(pathHtmlPage);
}

app.whenReady().then(() => {
    API.open();
    createWindow(loginPagePath);
});

app.on('window-all-closed', () => {
    if(process.platform !== 'darwin')
        app.quit();
});
