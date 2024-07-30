const { ipcRenderer } = require('electron');

document.getElementById("Clients").addEventListener("click", () => {
    ipcRenderer.send("openAllClients");
})

document.getElementById("Tables").addEventListener("click", () => {
    ipcRenderer.send("openTables");
})
