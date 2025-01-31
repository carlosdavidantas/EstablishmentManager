const API = require("../../../scripts/server/API.js");
const getDB = require("../../../scripts/server/getDB.js");
const putDB = require("../../../scripts/server/putDB.js");
const deleteDB = require("../../../scripts/server/deleteDB.js");
const { ipcRenderer } = require("electron"); // ipcrenderer is needed to receive the client id from the previous page.
const { dateFormatter, birthdayTypingMask, cpfTypingMask } = require("../../../scripts/js/utils.js");
const { createPhoneObject, createAddressesObject } = require("./createHtmlElements.js");
const { insertClientBasicInfomation, clientFieldsDisabled } = require("./infoInsertersOnTheScreen.js");


const clientRoute = `${API.URL}get/client/`;

const elementPhoneList = document.getElementById("phonesList");
const elementAddressesList = document.getElementById("addressesList");
const clientInfosEditButton = document.getElementById("clientInfosEditButton");
const clientDeleteButton = document.getElementById("clientDeleteButton");

let nameTextBoxElement = document.getElementById("name");
let cpfTextBoxElement = document.getElementById("cpf");
let birthdayTextBoxElement = document.getElementById("birthday");
let rgTextBoxElement = document.getElementById("rg");
let creationDateTextTextBoxElement = document.getElementById("creation_date");
let modifiedDateTextBoxElement = document.getElementById("modified_date");
let debitTextBoxElement = document.getElementById("debit_on_establishment");
let creditTextBoxElement = document.getElementById("credit_on_establishment");


let clientId;
ipcRenderer.on("receivedClientId", async (event, id) => {
    clientId = id;

    const clientURL = `${clientRoute}${clientId}`;
    await getAllClientInfoByClientId(clientURL);
    insertAllClientInformationOnScreen();
});

let clientPrimaryInfos;
let phonesList;
let addressesList;
async function getAllClientInfoByClientId(clientURL) {
    const clientResponse = await getDB.execute(clientURL);
    clientPrimaryInfos = clientResponse[1][0];
    phonesList = clientResponse[1][0].client_telephones;
    addressesList = clientResponse[1][0].client_addresses;
}

function iterateAndCreate (objectArray, func, listElement) {
    objectArray.forEach(element => {
        func(element, listElement);
    });
}

async function insertAllClientInformationOnScreen() {
    clientPrimaryInfos["birthday"] = dateFormatter(clientPrimaryInfos["birthday"]);
    insertClientBasicInfomation(
        clientPrimaryInfos,
        nameTextBoxElement,
        cpfTextBoxElement,
        birthdayTextBoxElement,
        rgTextBoxElement,
        creationDateTextTextBoxElement,
        modifiedDateTextBoxElement,
        debitTextBoxElement,
        creditTextBoxElement
    );

    iterateAndCreate(phonesList, createPhoneObject, elementPhoneList);
    iterateAndCreate(addressesList, createAddressesObject, elementAddressesList);
}

function deleteClient() {
    deleteDB.execute(`${API.URL}delete/client/${clientId}`);
    setTimeout(() => {
        ipcRenderer.send("updateAllClients");
    }, 100);
}


birthdayTextBoxElement.addEventListener("input", function(e) {  // Function that verificates and formats data sent by user.
    let value = birthdayTypingMask(e);
    e.target.value = value;
});

cpfTextBoxElement.addEventListener("input", function(e) {  // Function that formats data sent by user.
    let value = cpfTypingMask(e);
    e.target.value = value;
});

rgTextBoxElement.addEventListener("input", function(e) {  // Function that formats data sent by user.
    let value = e.target.value.replace(/\D/g, '');
    
    if(value.length > 2) {
        value = value.slice(0,2) + "." + value.slice(2);
    }

    if(value.length > 6){
        value = value.slice(0, 6) + "." + value.slice(6);
    }
    if(value.length > 10){
        value = value.slice(0, 10) + "-" + value.slice(10);
    }
    
    e.target.value = value;
});


const arrayOfClientFields = [
    nameTextBoxElement,
    cpfTextBoxElement,
    birthdayTextBoxElement,
    rgTextBoxElement,
    debitTextBoxElement,
    creditTextBoxElement
];
clientInfosEditButton.addEventListener("click", () => {
    if(clientInfosEditButton.innerHTML === "Edit") {
        clientInfosEditButton.innerText = "Save";
        clientFieldsDisabled(false, arrayOfClientFields
        );
        return;
    }

    if(clientInfosEditButton.innerHTML === "Save") {
        const date = birthdayTextBoxElement.value;
        const day = date.slice(0, 2);
        const month = date.slice(3, 5);
        const year = date.slice(6, 10);
        const newDate = `${year}-${month}-${day}`
        try {
            let newClient = {
                birthday: newDate,
                cpf: cpfTextBoxElement.value,
                credit_on_establishment: creditTextBoxElement.value,
                debit_on_establishment: debitTextBoxElement.value,
                name: nameTextBoxElement.value,
                rg: rgTextBoxElement.value
            }
            
            const success = putDB.execute(`${API.URL}put/client/${clientId}`, newClient);
            success.then((success) => {
                if(success == true) {
                    
                }else {
                    alert("Error while updating client!");
                    window.close();
                }
            });
            
        }
        catch(error) {
            console.log("ERROR Occurred - " + error);
        }

        clientInfosEditButton.innerText = "Edit";
        clientFieldsDisabled(true, arrayOfClientFields);
        setTimeout(() => {
            ipcRenderer.send("updateAllClients");
        }, 100);
    }
});

clientDeleteButton.addEventListener("click", async () => {
    const response = await ipcRenderer.invoke("showClientDeleteDialog");
    if (response ===  0) {
        // User clicked Yes
        deleteClient();
        setTimeout(() => {
            window.close();
        }, 100);
    } else {
        // Do nothing
    }
});
