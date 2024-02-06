const API = require("../../scripts/API.js");
const getDB = require("../../scripts/getDB.js");
const { ipcRenderer } = require("electron");

const clientList = document.getElementById("clientList");
const allClientsRoute = `${API.URL}get/clients`;

let clients;
let allClientsResponse;

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

async function getAllClients() {
    allClientsResponse = await getDB.execute(allClientsRoute);
    clients = allClientsResponse[1];
    clients.forEach((client) => {
        createClientObject(`${client.name}`, `${client.client_telephones[0].number}`, `${client.creation_date}`, client.clientId);
    });
}
getAllClients();
