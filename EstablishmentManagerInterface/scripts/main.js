const {app, BrowserWindow} = require("electron");
const nodePath = require("node:path");
const openAPI = require("./openAPI.js");

const createWindow = () => {
    const window = new BrowserWindow({
        width: 800,
        height: 600,
        webPreferences: {
            preload: nodePath.join(__dirname, "preload.js")
        }
    });
    
    window.loadFile("./pages/login/login.html");
}

app.whenReady().then(() => {
    createWindow();
    openAPI.execute();
});

app.on('window-all-closed', () => {
    if(process.platform !== 'darwin')
        app.quit();
});