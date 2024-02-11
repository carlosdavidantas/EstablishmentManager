const { app, BrowserWindow, ipcMain, dialog } = require("electron");
const API = require("./API.js");
const loginPagePath = "./pages/login/login.html";
const singleClientPagePath = "./pages/client/singleClientForm/singleClientForm.html";
const allClientsPagePath = "./pages/client/client.html";
let APIExe;

function createWindow(pathHtmlPage, isMaximized) {
    const window = new BrowserWindow({
        width: 800,
        height: 600,
        webPreferences: {
            nodeIntegration: true,
            contextIsolation: false,
        }
    });
    if(isMaximized)
        window.maximize();
    window.loadFile(pathHtmlPage);
    return window;
}

app.whenReady().then(() => {
    APIExe = API.open();
    createWindow(loginPagePath, true);
});

app.on("window-all-closed", () => {
    if (process.platform !== "darwin") {
        app.quit();
        APIExe.kill();
    }
});

ipcMain.on("openAllClients", () => {
    createWindow(allClientsPagePath, true);
});

ipcMain.on("openSingleClient", (event, clientId) => {
    const window = createWindow(singleClientPagePath, false);
    window.webContents.on("did-finish-load", () => {
        window.webContents.send("receivedClientId", clientId);
    });
});

ipcMain.handle("showClientDeleteDialog", async () => {
    const result = await dialog.showMessageBox({
        type: 'warning',
        buttons: ['Yes', 'No'],
        defaultId:  1,
        cancelId:  1,
        title: 'Confirm Deletion',
        message: 'Are you sure you want to delete this client?'
    });
    return result.response;
});
