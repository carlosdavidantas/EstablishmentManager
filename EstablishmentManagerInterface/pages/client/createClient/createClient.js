const API = require("../../../scripts/API.js");
const postDB = require("../../../scripts/postDB.js");
const { ipcRenderer } = require("electron");

const elementPhoneList = document.getElementById("phonesList");
const addNewTelephoneObject = document.getElementById("addNewTelephoneObject");
const addNewAddressObject = document.getElementById("addNewAddressObject");
const elementAddressesList = document.getElementById("addressesList");
const clientSaveButton = document.getElementById("clientSaveButton");


let nameTextBoxElement = document.getElementById("nameText");
let cpfTextBoxElement = document.getElementById("cpfText");
let birthdayTextBoxElement = document.getElementById("birthdayText");
let rgTextBoxElement = document.getElementById("rgText");
let debitTextBoxElement = document.getElementById("debitText");
let creditTextBoxElement = document.getElementById("creditText");

let telephonesObjectsCount = 0;
let addressesObjectCount = 0;


function createTelephoneObject() {
    const div = document.createElement("div");
    div.className = "phoneObject";
    div.setAttribute("id", `telephoneObject-${telephonesObjectsCount}`);

    const descriptionTextLabel = document.createElement("label");
    descriptionTextLabel.className = "infoObjectLabel";
    descriptionTextLabel.innerText = "Description:";
    

    const descriptionTextBox = document.createElement("input");
    descriptionTextBox.className = "objectTextBox";
    descriptionTextBox.setAttribute("id", `telephoneDescriptionTextBox-${telephonesObjectsCount}`);
    descriptionTextBox.placeholder = "Principal";
    descriptionTextBox.maxLength = "100";

    const numberTextLabel = document.createElement("label");
    numberTextLabel.className = "infoObjectLabel";
    numberTextLabel.innerText = "Number:";

    const numberTextBox = document.createElement("input");
    numberTextBox.className = "objectTextBox";
    numberTextBox.setAttribute("id", `telephoneNumberTextBox-${telephonesObjectsCount}`);
    numberTextBox.maxLength = "13";


    div.appendChild(descriptionTextLabel);
    div.appendChild(descriptionTextBox);
    div.appendChild(numberTextLabel);
    div.appendChild(numberTextBox);

    elementPhoneList.appendChild(div);
    telephonesObjectsCount++;
}
createTelephoneObject();

function createAddressesObject() {
    const div = document.createElement("div");
    div.className = "addressObject";
    div.setAttribute("id", `addressObject-${addressesObjectCount}`);

    const streetNameTextLabel = document.createElement("label");
    streetNameTextLabel.className = "infoObjectLabel";
    streetNameTextLabel.innerText = "Street name:";

    const streetNameTextBox = document.createElement("input");
    streetNameTextBox.className = "objectTextBox";
    streetNameTextBox.setAttribute("id", `addressStreetNameTextBox-${addressesObjectCount}`);
    streetNameTextBox.maxLength = "100";

    const complementTextLabel = document.createElement("label");
    complementTextLabel.className = "infoObjectLabel";
    complementTextLabel.innerText = "Complement:";

    const complementTextBox = document.createElement("input");
    complementTextBox.className = "objectTextBox";
    complementTextBox.setAttribute("id", `addressComplementTextBox-${addressesObjectCount}`);
    complementTextBox.maxLength = "100";

    const referenceTextLabel = document.createElement("label");
    referenceTextLabel.className = "infoObjectLabel";
    referenceTextLabel.innerText = "Reference:";

    const referenceTextBox = document.createElement("input");
    referenceTextBox.className = "objectTextBox";
    referenceTextBox.setAttribute("id", `addressReferenceTextBox-${addressesObjectCount}`);
    referenceTextBox.maxLength = "100";

    const districtTextLabel = document.createElement("label");
    districtTextLabel.className = "infoObjectLabel";
    districtTextLabel.innerText = "District:";

    const districtTextBox = document.createElement("input");
    districtTextBox.className = "objectTextBox";
    districtTextBox.setAttribute("id", `addressDistrictTextBox-${addressesObjectCount}`);
    districtTextBox.maxLength = "100";

    const cepTextLabel = document.createElement("label");
    cepTextLabel.className = "infoObjectLabel";
    cepTextLabel.innerText = "CEP:";

    const cepTextBox = document.createElement("input");
    cepTextBox.className = "objectTextBox";
    cepTextBox.setAttribute("id", `addressCepTextBox-${addressesObjectCount}`);
    cepTextBox.maxLength = "9";
    cepTextBox.placeholder = "00000-000";

    const numberTextLabel = document.createElement("label");
    numberTextLabel.className = "infoObjectLabel";
    numberTextLabel.innerText = "Number:";

    const numberTextBox = document.createElement("input");
    numberTextBox.className = "objectTextBox";
    numberTextBox.setAttribute("id", `addressNumberTextBox-${addressesObjectCount}`);
    numberTextBox.maxLength = "50";

    const descriptionTextLabel = document.createElement("label");
    descriptionTextLabel.className = "infoObjectLabel";
    descriptionTextLabel.innerText = "Description:";

    const descriptionTextBox = document.createElement("input");
    descriptionTextBox.className = "objectTextBox";
    descriptionTextBox.setAttribute("id", `addressDescriptionTextBox-${addressesObjectCount}`);
    descriptionTextBox.maxLength = "100";
    descriptionTextBox.placeholder = "Principal";
    


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

    elementAddressesList.appendChild(div);
    addressesObjectCount++;
}
createAddressesObject();


addNewTelephoneObject.addEventListener("click", () => {
    createTelephoneObject();
});

addNewAddressObject.addEventListener("click", () => {
    createAddressesObject();
});

function createClientObject() {
    let clientAddressesArray = [];
    let clientTelephonesArray = [];

    for (let addressObject = 0; addressObject < addressesObjectCount; addressObject++) {
        console.log(addressObject);
        const addressCepTextBox = document.getElementById(`addressCepTextBox-${addressObject}`).value;
        const addressComplementTextBox = document.getElementById(`addressComplementTextBox-${addressObject}`).value;
        const addressDescriptionTextBox = document.getElementById(`addressDescriptionTextBox-${addressObject}`).value;
        const addressDistrictTextBox = document.getElementById(`addressDistrictTextBox-${addressObject}`).value;
        const addressNumberTextBox = document.getElementById(`addressNumberTextBox-${addressObject}`).value;
        const addressReferenceTextBox = document.getElementById(`addressReferenceTextBox-${addressObject}`).value;
        const addressStreetNameTextBox = document.getElementById(`addressStreetNameTextBox-${addressObject}`).value;

        const address = {
            cep: addressCepTextBox,
            complement: addressComplementTextBox,
            description: addressDescriptionTextBox,
            district: addressDistrictTextBox,
            number: addressNumberTextBox,
            reference: addressReferenceTextBox,
            street_name: addressStreetNameTextBox
        }
        clientAddressesArray.push(address);
    }

    for (let telephoneObject = 0; telephoneObject < telephonesObjectsCount; telephoneObject++) {
        const telephoneDescriptionTextBox = document.getElementById(`telephoneDescriptionTextBox-${telephoneObject}`).value;
        const telephoneNumberTextBox = document.getElementById(`telephoneNumberTextBox-${telephoneObject}`).value;

        const telephone = {
            description: telephoneDescriptionTextBox,
            number: telephoneNumberTextBox
        }
        clientTelephonesArray.push(telephone);
    }

    const d = birthdayTextBoxElement.value.slice(0, 2);
    const m = birthdayTextBoxElement.value.slice(3, 5);
    const y = birthdayTextBoxElement.value.slice(6, 10);
    const bithdayDateFomatted = `${y}-${m}-${d}`;
    
    const client = {
        birthday: bithdayDateFomatted,
        client_addresses: clientAddressesArray,
        client_telephones: clientTelephonesArray,
        cpf: cpfTextBoxElement.value,
        credit_on_establishment: creditTextBoxElement.value,
        debit_on_establishment: debitTextBoxElement.value,
        name: nameTextBoxElement.value,
        rg: rgTextBoxElement.value
    }

    return client;
}

clientSaveButton.addEventListener("click", async () => {
    const client = createClientObject();
    const result = await postDB.execute(`${API.URL}post/clients`, client);
    if(result === true) {
        setTimeout(() => {
            ipcRenderer.send("updateAllClients");
            window.close();
        }, 100);
    }
    else {
        const response = await ipcRenderer.invoke("errorWhileCreatingTheClient");
        if (response ===  0) {
            //Do nothing
        } else {
            window.close();
        }
    }
});

birthdayTextBoxElement.addEventListener("input", function(e) {  // Function that verificates and formats data sent by user.
    let value = e.target.value.replace(/\D/g, '');
    
    if(value.length > 2) {
        let day = parseInt(value.slice(0,2), 10);
        if(day > 31){
            value = "31";
        }else {
            value = value.slice(0,2) + "/" + value.slice(2);
        }
    }

    if(value.length > 5){
        let month = parseInt(value.slice(3, 5), 10);
        if (month > 12) {
            value = value.slice(0, 2) + "/12";
        } else {
            value = value.slice(0, 5) + "/" + value.slice(5);
        }
    }
    if(value.length >= 10){
        let year = parseInt(value.slice(6,10));
        let actualYear = new Date().getFullYear();
        if(year > actualYear){
            value = value.slice(0, 6) + `${actualYear}`;
        }
    }
    
    e.target.value = value;
});

cpfTextBoxElement.addEventListener("input", function(e) {  // Function that formats data sent by user.
    let value = e.target.value.replace(/\D/g, '');
    
    if(value.length > 3) {
        value = value.slice(0,3) + "." + value.slice(3);
    }

    if(value.length > 7){
        value = value.slice(0, 7) + "." + value.slice(7);
    }
    if(value.length > 11){
        value = value.slice(0, 11) + "-" + value.slice(11);
    }
    
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
