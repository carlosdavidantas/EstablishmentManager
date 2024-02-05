const API = require("../../../scripts/API.js");
const getDB = require("../../../scripts/getDB.js");
const id = 7;
const specificClientURL = `${API.URL}get/clients/${id}`;
const elementPhoneList = document.getElementById("phonesList");
const elementAddressesList = document.getElementById("addressesList");

let nameTextBoxElement = document.getElementById("nameText");
let cpfTextBoxElement = document.getElementById("cpfText");
let birthdayTextBoxElement = document.getElementById("birthdayText");
let rgTextBoxElement = document.getElementById("rgText");
let creationDateTextTextBoxElement = document.getElementById("creationDateText");
let modifiedDateTextBoxElement = document.getElementById("modifiedDateText");
let debitTextBoxElement = document.getElementById("debitText");
let creditTextBoxElement = document.getElementById("creditText");

let specificClientResponse;
let clientInfos;
let phonesList;
let addressesList;

function createPhoneObject(telephoneObject) {
    const div = document.createElement("div");
    div.className = "phoneObject";
    div.setAttribute("id", `phoneObjectId-${telephoneObject.client_telephoneId}`);

    const descriptionTextLabel = document.createElement("label");
    descriptionTextLabel.className = "infoObjectLabel";
    descriptionTextLabel.innerText = "Description:";

    const descriptionTextBox = document.createElement("input");
    descriptionTextBox.className = "objectTextBox";
    descriptionTextBox.value = telephoneObject.description;
    descriptionTextBox.disabled = true;

    const numberTextLabel = document.createElement("label");
    numberTextLabel.className = "infoObjectLabel";
    numberTextLabel.innerText = "Number:";

    const numberTextBox = document.createElement("input");
    numberTextBox.className = "objectTextBox";
    numberTextBox.value = telephoneObject.number;
    numberTextBox.disabled = true;

    const creationDateTextLabel = document.createElement("label");
    creationDateTextLabel.className = "infoObjectLabel";
    creationDateTextLabel.innerText = "Creation date:";

    const creationDateTextBox = document.createElement("input");
    creationDateTextBox.className = "objectTextBox";
    creationDateTextBox.value = telephoneObject.creation_date;
    creationDateTextBox.disabled = true;

    const modifiedDateTextLabel = document.createElement("label");
    modifiedDateTextLabel.className = "infoObjectLabel";
    modifiedDateTextLabel.innerText = "Modified date:";

    const modifiedDateTextBox = document.createElement("input");
    modifiedDateTextBox.className = "objectTextBox";
    modifiedDateTextBox.value = telephoneObject.modified_date;
    modifiedDateTextBox.disabled = true;

    const editButton = document.createElement("button");
    editButton.className = "editObjectButton";
    editButton.innerText = "Edit";

    editButton.addEventListener("click", (t) => {
        console.log(t);
    });

    div.appendChild(descriptionTextLabel);
    div.appendChild(descriptionTextBox);
    div.appendChild(numberTextLabel);
    div.appendChild(numberTextBox);
    div.appendChild(creationDateTextLabel);
    div.appendChild(creationDateTextBox);
    div.appendChild(modifiedDateTextLabel);
    div.appendChild(modifiedDateTextBox);
    div.appendChild(editButton);

    elementPhoneList.appendChild(div);
}

function createAddressesObject(addressObject) {
    const div = document.createElement("div");
    div.className = "addressObject";
    div.setAttribute("id", `addressObjectId-${addressObject.client_addressId}`);

    const streetNameTextLabel = document.createElement("label");
    streetNameTextLabel.className = "infoObjectLabel";
    streetNameTextLabel.innerText = "Street name:";

    const streetNameTextBox = document.createElement("input");
    streetNameTextBox.className = "objectTextBox";
    streetNameTextBox.value = addressObject.street_name;
    streetNameTextBox.disabled = true;

    const complementTextLabel = document.createElement("label");
    complementTextLabel.className = "infoObjectLabel";
    complementTextLabel.innerText = "Complement:";

    const complementTextBox = document.createElement("input");
    complementTextBox.className = "objectTextBox";
    complementTextBox.value = addressObject.complement;
    complementTextBox.disabled = true;

    const referenceTextLabel = document.createElement("label");
    referenceTextLabel.className = "infoObjectLabel";
    referenceTextLabel.innerText = "Reference:";

    const referenceTextBox = document.createElement("input");
    referenceTextBox.className = "objectTextBox";
    referenceTextBox.value = addressObject.reference;
    referenceTextBox.disabled = true;

    const districtTextLabel = document.createElement("label");
    districtTextLabel.className = "infoObjectLabel";
    districtTextLabel.innerText = "Distric:";

    const districtTextBox = document.createElement("input");
    districtTextBox.className = "objectTextBox";
    districtTextBox.value = "Needs to be added in the backend";
    districtTextBox.disabled = true;

    const cepTextLabel = document.createElement("label");
    cepTextLabel.className = "infoObjectLabel";
    cepTextLabel.innerText = "CEP:";

    const cepTextBox = document.createElement("input");
    cepTextBox.className = "objectTextBox";
    cepTextBox.value = addressObject.cep;
    cepTextBox.disabled = true;

    const numberTextLabel = document.createElement("label");
    numberTextLabel.className = "infoObjectLabel";
    numberTextLabel.innerText = "Number:";

    const numberTextBox = document.createElement("input");
    numberTextBox.className = "objectTextBox";
    numberTextBox.value = addressObject.number;
    numberTextBox.disabled = true;

    const descriptionTextLabel = document.createElement("label");
    descriptionTextLabel.className = "infoObjectLabel";
    descriptionTextLabel.innerText = "Description:";

    const descriptionTextBox = document.createElement("input");
    descriptionTextBox.className = "objectTextBox";
    descriptionTextBox.value = addressObject.description;
    descriptionTextBox.disabled = true;

    const creationDateTextLabel = document.createElement("label");
    creationDateTextLabel.className = "infoObjectLabel";
    creationDateTextLabel.innerText = "Creation date:";

    const creationDateTextBox = document.createElement("input");
    creationDateTextBox.className = "objectTextBox";
    creationDateTextBox.value = addressObject.creation_date;
    creationDateTextBox.disabled = true;

    const modifiedDateTextLabel = document.createElement("label");
    modifiedDateTextLabel.className = "infoObjectLabel";
    modifiedDateTextLabel.innerText = "Modified date:";

    const modifiedDateTextBox = document.createElement("input");
    modifiedDateTextBox.className = "objectTextBox";
    modifiedDateTextBox.value = addressObject.modified_date;
    modifiedDateTextBox.disabled = true;

    const editButton = document.createElement("button");
    editButton.className = "editObjectButton";
    editButton.innerText = "Edit";

    editButton.addEventListener("click", (t) => {
        console.log(t);
    });

    div.appendChild(streetNameTextLabel);
    div.appendChild(streetNameTextBox);
    div.appendChild(complementTextLabel);
    div.appendChild(complementTextBox);
    div.appendChild(referenceTextLabel);
    div.appendChild(referenceTextBox);
    div.appendChild(districtTextLabel);
    div.appendChild(districtTextBox);
    div.appendChild(cepTextLabel);
    div.appendChild(cepTextBox);
    div.appendChild(numberTextLabel);
    div.appendChild(numberTextBox);
    div.appendChild(descriptionTextLabel);
    div.appendChild(descriptionTextBox);
    div.appendChild(creationDateTextLabel);
    div.appendChild(creationDateTextBox);
    div.appendChild(modifiedDateTextLabel);
    div.appendChild(modifiedDateTextBox);
    div.appendChild(editButton);

    elementAddressesList.appendChild(div);
}

function insertClientBasicInfomation(client) {
    nameTextBoxElement.value = client.name;
    cpfTextBoxElement.value = client.cpf;
    birthdayTextBoxElement.value = client.birthday;
    rgTextBoxElement.value = client.rg;
    creationDateTextTextBoxElement.value = client.creation_date;
    modifiedDateTextBoxElement.value = client.modified_date;
    debitTextBoxElement.value = client.debit_on_establishment;
    creditTextBoxElement.value = client.credit_on_establishment;
}

async function insertInformationOnScreen() {
    specificClientResponse = await getDB.execute(specificClientURL);
    clientInfos = specificClientResponse[1][0];
    insertClientBasicInfomation(clientInfos);

    phonesList = specificClientResponse[1][0].client_telephones;
    phonesList.forEach((telephone) => {
        createPhoneObject(telephone)
    });

    addressesList = specificClientResponse[1][0].client_addresses;
    addressesList.forEach((address) => {
        createAddressesObject(address);
    });
}
insertInformationOnScreen()
