const API = require("../../scripts/API.js");
const getDB = require("../../scripts/getDB.js");
const allClientsRoute = `${API.URL}clients`;
const clientList = document.getElementById("clientList");

let clients;
let allClientsResponse;

function createClientObject(name, phone, creationDate) {
    const section = document.createElement("section");
    section.className = "clientObject";

    const nameTextLabel = document.createElement("label");
    nameTextLabel.className = "NameText";
    nameTextLabel.setAttribute("text", `${name}`);
    nameTextLabel.innerText = `${name}`;

    const phoneTextLabel = document.createElement("label");
    phoneTextLabel.className = "PhoneText";
    phoneTextLabel.setAttribute("text", `${phone}`);
    phoneTextLabel.innerText = `${phone}`;

    const creationDateTextLabel = document.createElement("label");
    creationDateTextLabel.className = "CreationDateText";
    creationDateTextLabel.setAttribute("text", `${creationDate}`);
    creationDateTextLabel.innerText = `${creationDate}`;

    section.appendChild(nameTextLabel);
    section.appendChild(phoneTextLabel);
    section.appendChild(creationDateTextLabel);
    clientList.appendChild(section);
}

async function getAllClients() {
    allClientsResponse = await getDB.execute(allClientsRoute);
    clients = allClientsResponse[1];
    clients.forEach(client => {
        createClientObject(`${client.name}`, `${client.client_telephones[0].number}`, `${client.creation_date}`);
    });
}
getAllClients();

