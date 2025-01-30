const API = require("../../../scripts/API.js");
const getDB = require("../../../scripts/getDB.js");
const { ipcRenderer } = require("electron");

const clientList = document.getElementById("clientList");
const clientsRoute = `${API.URL}get/clients`;

const searchButton = document.getElementById("searchButton");
const searchTextbox = document.getElementById("searchText");
const createNewClientButton = document.getElementById("createNewClientButton");

let searchResponse;

async function getAllClients() {
    searchResponse = await getDB.execute(clientsRoute);
    clientsArray = searchResponse[1];
    return clientsArray;
}

async function updateClientList() {
    clearClientList();
    clientsArray = await getAllClients();
    populateClientList(clientsArray);
}
updateClientList();

function populateClientList(clientArray) {
    clientArray.forEach((client) => {
        createClientObject(`${client.name}`, `${client.client_telephones[0].number}`, `${client.creation_date}`, client.clientId);
    });
}

function clearSearchTextbox() {
    searchText.value = "";
}

function clearClientList() {
    clientList.innerHTML = "";
    searchResponse = null;
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
    const d = creationDate.slice(8, 10);
    const m = creationDate.slice(5, 7);
    const y = creationDate.slice(0, 4);
    creationDateTextLabel.innerText = `${d}/${m}/${y}`;

    div.appendChild(nameTextLabel);
    div.appendChild(phoneTextLabel);
    div.appendChild(creationDateTextLabel);

    nameTextLabel.addEventListener("click", (object) => {
        const clientClickedId = object.target.id;
        ipcRenderer.send("openSingleClient", clientClickedId);
    });

    clientList.appendChild(div);
}

async function getSpecificClients(specificClientInfo) {
    let clientArray = await getAllClients();
    const lowerCaseInfo = specificClientInfo.toLowerCase();

    // Filters the client array to get only the clients that match with the search text
    const clientFilter = clientArray.filter((client) => {
        // Verifies name, cpf and rg for matches
        if (client.name.toLowerCase().includes(lowerCaseInfo) || 
            client.cpf.includes(lowerCaseInfo) ||
            client.rg.includes(lowerCaseInfo)) {
            return true;
        }
        
        // Verifies telephones for matches
        const hasPhone = client.client_telephones.some(telephone => 
            telephone.number.includes(lowerCaseInfo)
        );
        if (hasPhone) return true;
        
        // Verifies addresses for matches
        const hasAddress = client.client_addresses.some(address =>
            address.cep.includes(lowerCaseInfo) ||
            address.district.toLowerCase().includes(lowerCaseInfo) ||
            address.street_name.toLowerCase().includes(lowerCaseInfo)
        );
        if (hasAddress) return true;
        
        return false;
    });
    clearClientList();
    populateClientList(clientFilter);
    // if(specificClientInfo !== undefined, ""){
    //     try {
    //         clearClientList();
    //         searchResponse = await getDB.execute(`${clientsRoute}/${specificClientInfo}`);
    //         clients = searchResponse[1];
    //         populateClientList(clients);

    //     }catch(error) {
    //         console.log(error);
    //         clearClientList();
    //         searchResponse = await getDB.execute(clientsRoute);
    //         clients = searchResponse[1];
    //         let newClientSearch = [];
    //         clients.forEach((client) => {
    //             client.client_telephones.forEach((telephone) => {
    //                 if(telephone.number === specificClientInfo) {
    //                     newClientSearch.push(client);
    //                     return;
    //                 }
    //             });

    //             client.client_addresses.forEach((address) => {
    //                 if(address.cep === specificClientInfo || address.distric === specificClientInfo
    //                     || address.street_name === specificClientInfo) {
    //                         newClientSearch.push(client);
    //                         return;
    //                     }
    //             });
    //         });
    //         populateClientList(newClientSearch);
    //     }
    // }
    // else{
    //     clearClientList();
    //     try {
    //         searchResponse = await getDB.execute(clientsRoute);
    //         clients = searchResponse[1];
    //         populateClientList(clients);
    //     } catch(error) {
    //         console.log("No clients found");
    //     }
    // }
}

searchTextbox.addEventListener("keydown", async (keydownEvent) => {
    if(keydownEvent.key === "Enter"){
        if(searchTextbox.value.trim() === ""){
            updateClientList();
            clearSearchTextbox();
            return;
        }

        const searchInput = searchTextbox.value;
        getSpecificClients(searchInput);
    }
});

searchButton.addEventListener("click", async () => {
    const searchInput = searchTextbox.value;
    if(searchTextbox.value.trim() === ""){
        updateClientList();
        clearSearchTextbox();
        return;
    }

    getSpecificClients(searchInput);
});

createNewClientButton.addEventListener("click", () => {
    ipcRenderer.send("createNewClientWindow");
});

ipcRenderer.on("updateAllClients", () => {
    updateClientList();
})