const { app, BrowserWindow, ipcMain, dialog } = require("electron");
const API = require("./API.js");
const loginPagePath = "./pages/login/login.html";
const singleClientPagePath = "./pages/client/singleClient/singleClient.html";
const allClientsPagePath = "./pages/client/clientsHome/clients.html";
const tablesPagePath = "./pages/tables/tables.html";
const createClientPath = "./pages/client/createClient/createClient.html";
let APIExe;

let windowsRegistry = {};

function createWindow(pathHtmlPage, isMaximized, identifier) {
    const window = new BrowserWindow({
        width: 800,
        height: 600,
        minWidth: 600,
        minHeight: 600,
        webPreferences: {
            nodeIntegration: true,
            contextIsolation: false,
        }
    });
    if(isMaximized)
        window.maximize();
    window.loadFile(pathHtmlPage);
    if(identifier !== "")
        windowsRegistry[identifier] = window;
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
    createWindow(allClientsPagePath, true, "allClients");
});

ipcMain.on("openTables", () => {
    createWindow(tablesPagePath, true, "tables");
});

ipcMain.on("openSingleClient", (event, clientId) => {
    const window = createWindow(singleClientPagePath, false, "singleClient");
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

ipcMain.on("createNewClientWindow", () => {
    createWindow(createClientPath, true, "createNewClient");
});

ipcMain.handle("errorWhileCreatingTheClient", async () => {
    const result = await dialog.showMessageBox({
        type: 'warning',
        buttons: ['Yes', 'No'],
        defaultId:  1,
        cancelId:  1,
        title: 'Error while creating the client',
        message: 'Do you want to try again?'
    });
    return result.response;
});

ipcMain.on("updateAllClients", () => {
    console.log("Executing");
    windowsRegistry["allClients"].webContents.send("updateAllClients");
});

