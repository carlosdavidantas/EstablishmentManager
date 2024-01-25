const {app, BrowserWindow} = require('electron');
const openAPI = require("./openAPI.js");

const createWindow = () => {
    const window = new BrowserWindow({
        width: 800,
        height: 600
    });
    window.loadFile('pages\\login.html');
    openAPI.execute();
}

app.whenReady().then(() => {
    createWindow();
});

app.on('window-all-closed', () => {
    if(process.platform !== 'darwin')
        app.quit();
});