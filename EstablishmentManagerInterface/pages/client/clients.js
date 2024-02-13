const API = require("../../scripts/API.js");
const getDB = require("../../scripts/getDB.js");
const { ipcRenderer } = require("electron");

const clientList = document.getElementById("clientList");
const clientsRoute = `${API.URL}get/clients`;

const searchButton = document.getElementById("searchButton");
const searchTextbox = document.getElementById("searchText");
const createNewClientButton = document.getElementById("createNewClientButton");

let clients;
let searchResponse;


function clearClientList() {
    clientList.innerHTML = "";
    searchResponse = null;
    clients = null;
}

function createClientObject(name, phone, creationDate, id) {
    const div = document.createElement("div");
    div.className = "clientObject";
    div.setAttribute("id", id);

    const nameTextLabel = document.createElement("label");
    nameTextLabel.className = "NameText";
    nameTextLabel.setAttribute("text", `${name}`);
    nameTextLabel.setAttribute("id", id);
    nameTextLabel.innerText = `${name}`;

    const phoneTextLabel = document.createElement("label");
    phoneTextLabel.className = "PhoneText";
    phoneTextLabel.setAttribute("text", `${phone}`);
    phoneTextLabel.innerText = `${phone}`;

    const creationDateTextLabel = document.createElement("label");
    creationDateTextLabel.className = "CreationDateText";
    creationDateTextLabel.setAttribute("text", `${creationDate}`);
    creationDateTextLabel.innerText = `${creationDate}`;

    div.appendChild(nameTextLabel);
    div.appendChild(phoneTextLabel);
    div.appendChild(creationDateTextLabel);

    nameTextLabel.addEventListener("click", (object) => {
        const clientClickedId = object.target.id;
        ipcRenderer.send("openSingleClient", clientClickedId);
    });

    clientList.appendChild(div);
}

function loopThroughClients(clientArray) {
    clientArray.forEach((client) => {
        createClientObject(`${client.name}`, `${client.client_telephones[0].number}`, `${client.creation_date}`, client.clientId);
    });
}

async function searchForClientOnDB(specificClientInfo) {
    if(specificClientInfo != undefined){
        try {
            clearClientList();
            searchResponse = await getDB.execute(`${clientsRoute}/${specificClientInfo}`);
            clients = searchResponse[1];
            loopThroughClients(clients);

        }catch(error) {
            clearClientList();
            searchResponse = await getDB.execute(clientsRoute);
            clients = searchResponse[1];
            let newClientSearch = [];
            clients.forEach((client) => {
                client.client_telephones.forEach((telephone) => {
                    if(telephone.number === specificClientInfo) {
                        newClientSearch.push(client);
                        return;
                    }
                });

                client.client_addresses.forEach((address) => {
                    if(address.cep === specificClientInfo || address.distric === specificClientInfo
                        || address.street_name === specificClientInfo) {
                            newClientSearch.push(client);
                            return;
                        }
                });
            });
            loopThroughClients(newClientSearch);
        }
    }
    else{
        clearClientList();
        try {
            searchResponse = await getDB.execute(clientsRoute);
            clients = searchResponse[1];
            loopThroughClients(clients);
        } catch(error) {
            console.log(error);
        }
    }
}
searchForClientOnDB();

searchTextbox.addEventListener("keydown", async (keydownEvent) => {
    if(keydownEvent.key === "Enter"){
        clearClientList();

        const searchInput = searchTextbox.value;
        searchForClientOnDB(searchInput);
    }
});

searchButton.addEventListener("click", async () => {
    clearClientList();

    const searchInput = searchTextbox.value;
    searchForClientOnDB(searchInput);
});

createNewClientButton.addEventListener("click", () => {
    ipcRenderer.send("createNewClient");
});
