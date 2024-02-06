const { ipcRenderer } = require('electron');

document.getElementById("Clients").addEventListener("click", () => {
    ipcRenderer.send("openAllClients");
})
