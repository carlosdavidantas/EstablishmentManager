const clientPagePath = "../client/client.html";

document.getElementById("Clients").addEventListener("click", () => { 
    window.open(clientPagePath, "Clients", "frame=true,nodeIntegration=yes,contextIsolation=no");
})
