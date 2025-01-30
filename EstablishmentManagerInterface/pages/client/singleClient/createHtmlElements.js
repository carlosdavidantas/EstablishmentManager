const { ipcRenderer } = require("electron");
const API = require("../../../scripts/server/API.js");
const deleteDB = require("../../../scripts/server/deleteDB.js");
const putDB = require("../../../scripts/server/putDB.js");
const { dateFormatter } = require("../../../scripts/js/utils.js");


// This function creates the html element with the client's telephone information filled to be inserted in the telephones list of the page.
function createPhoneObject(telephoneObject, elementPhoneList) {
    const div = document.createElement("div");
    div.className = "phoneObject";
    div.setAttribute("id", `phoneObjectId-${telephoneObject.client_telephoneId}`);

    const titleDiv = document.createElement("div");
    titleDiv.className = "topBackground";

    const descriptionTextLabel = document.createElement("label");
    descriptionTextLabel.className = "infoObjectLabel";
    descriptionTextLabel.innerText = "Description:";
    

    const descriptionTextBox = document.createElement("input");
    descriptionTextBox.className = "objectTextBox";
    descriptionTextBox.value = telephoneObject.description;
    descriptionTextBox.disabled = true;
    descriptionTextBox.setAttribute("id", `descriptionTextBox-${telephoneObject.client_telephoneId}`);
    descriptionTextBox.placeholder = "Principal";
    descriptionTextBox.maxLength = "100";

    const numberTextLabel = document.createElement("label");
    numberTextLabel.className = "infoObjectLabel";
    numberTextLabel.innerText = "Number:";

    const numberTextBox = document.createElement("input");
    numberTextBox.className = "objectTextBox";
    numberTextBox.value = telephoneObject.number;
    numberTextBox.disabled = true;
    numberTextBox.maxLength = "13";
    numberTextBox.setAttribute("id", `numberTextBox-${telephoneObject.client_telephoneId}`);
    
    const creationDateTextLabel = document.createElement("label");
    creationDateTextLabel.className = "infoObjectLabel";
    creationDateTextLabel.innerText = "Creation date:";

    const creationDateTextBox = document.createElement("input");
    creationDateTextBox.className = "objectTextBox";
    creationDateTextBox.value = dateFormatter(telephoneObject.creation_date);
    creationDateTextBox.disabled = true;

    const modifiedDateTextLabel = document.createElement("label");
    modifiedDateTextLabel.className = "infoObjectLabel";
    modifiedDateTextLabel.innerText = "Modified date:";
    
    const modifiedDateTextBox = document.createElement("input");
    modifiedDateTextBox.className = "objectTextBox";
    modifiedDateTextBox.value = dateFormatter(telephoneObject.modified_date);
    modifiedDateTextBox.disabled = true;
    modifiedDateTextBox.setAttribute("id", `modifiedDateTextBox-${telephoneObject.client_telephoneId}`);

    const buttonsDiv = document.createElement("div");
    buttonsDiv.className = "phoneButtonsDiv";
    
    const editButton = document.createElement("button");
    editButton.className = "editPhoneObjectButton";
    editButton.id = `${telephoneObject.clientId}`;

    const editIcon = document.createElement("img");
    editIcon.className = "editPhoneIcon";
    editIcon.src = "../../../icons/pencil-edit.svg";
    editButton.appendChild(editIcon);

    const deleteButton = document.createElement("button");
    deleteButton.className = "deletePhoneObjectButtom";
    deleteButton.id = `${telephoneObject.clientId}`;
    
    const deleteIcon = document.createElement("img");
    deleteIcon.className = "deletePhoneIcon";
    deleteIcon.src = "../../../icons/trash-delete.svg";
    deleteButton.appendChild(deleteIcon);

    function fieldsDisabled (boolValue) {
        descriptionTextBox.disabled = boolValue;
        numberTextBox.disabled = boolValue;
    }

    editButton.addEventListener("click", () => {
        const editIconVar = editButton.children[0];

        if(editIconVar.src.includes("pencil-edit.svg")) {
            editIconVar.src = "../../../icons/floppy-save.svg";
            fieldsDisabled(false);
            return;
        }

        if(editIconVar.src.includes("floppy-save.svg")) {
            try {
                let newTelephone = {
                    number: numberTextBox.value,
                    description: descriptionTextBox.value,
                }
                putDB.execute(`${API.URL}put/telephone/${telephoneObject.client_telephoneId}`, newTelephone);
            }
            catch(error) {
                console.log("ERROR Occurred - " + error);
            }

            editIconVar.src = "../../../icons/pencil-edit.svg";
            fieldsDisabled(true);
            setTimeout(() => {
                ipcRenderer.send("updateAllClients");
            }, 100);
        }
    });

    deleteButton.addEventListener("click", () => {
        try {
            if(elementPhoneList.children.length > 1) {
                deleteDB.execute(`${API.URL}delete/telephone/${telephoneObject.client_telephoneId}`);
                div.remove();
                setTimeout(() => {
                    ipcRenderer.send("updateAllClients");
                }, 100);
            }
        }
        catch(error) {
            console.log("ERROR Occurred - " + error);
        }
    });

    div.appendChild(titleDiv);
    titleDiv.appendChild(descriptionTextLabel);
    titleDiv.appendChild(buttonsDiv);
    buttonsDiv.appendChild(editButton);
    buttonsDiv.appendChild(deleteButton);
    div.appendChild(descriptionTextBox);
    div.appendChild(numberTextLabel);
    div.appendChild(numberTextBox);
    div.appendChild(creationDateTextLabel);
    div.appendChild(creationDateTextBox);
    div.appendChild(modifiedDateTextLabel);
    div.appendChild(modifiedDateTextBox);

    elementPhoneList.appendChild(div);
}

// This function creates the html element with the client's address information filled to be inserted into the addresses list of the page. 
function createAddressesObject(addressObject, elementAddressesList) {
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
    streetNameTextBox.maxLength = "100";

    const complementTextLabel = document.createElement("label");
    complementTextLabel.className = "infoObjectLabel";
    complementTextLabel.innerText = "Complement:";

    const complementTextBox = document.createElement("input");
    complementTextBox.className = "objectTextBox";
    complementTextBox.value = addressObject.complement;
    complementTextBox.disabled = true;
    complementTextBox.maxLength = "100";

    const referenceTextLabel = document.createElement("label");
    referenceTextLabel.className = "infoObjectLabel";
    referenceTextLabel.innerText = "Reference:";

    const referenceTextBox = document.createElement("input");
    referenceTextBox.className = "objectTextBox";
    referenceTextBox.value = addressObject.reference;
    referenceTextBox.disabled = true;
    referenceTextBox.maxLength = "100";

    const districtTextLabel = document.createElement("label");
    districtTextLabel.className = "infoObjectLabel";
    districtTextLabel.innerText = "District:";

    const districtTextBox = document.createElement("input");
    districtTextBox.className = "objectTextBox";
    districtTextBox.value = addressObject.district;
    districtTextBox.disabled = true;
    districtTextBox.maxLength = "50";

    const cepTextLabel = document.createElement("label");
    cepTextLabel.className = "infoObjectLabel";
    cepTextLabel.innerText = "CEP:";
    
    const cepTextBox = document.createElement("input");
    cepTextBox.className = "objectTextBox";
    cepTextBox.value = addressObject.cep;
    cepTextBox.disabled = true;
    cepTextBox.maxLength = "9";
    cepTextBox.placeholder = "00000-000";

    const numberTextLabel = document.createElement("label");
    numberTextLabel.className = "infoObjectLabel";
    numberTextLabel.innerText = "Number:";

    const numberTextBox = document.createElement("input");
    numberTextBox.className = "objectTextBox";
    numberTextBox.value = addressObject.number;
    numberTextBox.disabled = true;
    numberTextBox.maxLength = "50";

    const descriptionTextLabel = document.createElement("label");
    descriptionTextLabel.className = "infoObjectLabel";
    descriptionTextLabel.innerText = "Description:";

    const descriptionTextBox = document.createElement("input");
    descriptionTextBox.className = "objectTextBox";
    descriptionTextBox.value = addressObject.description;
    descriptionTextBox.disabled = true;
    descriptionTextBox.maxLength = "100";
    descriptionTextBox.placeholder = "Principal";

    const creationDateTextLabel = document.createElement("label");
    creationDateTextLabel.className = "infoObjectLabel";
    creationDateTextLabel.innerText = "Creation date:";

    const creationDateTextBox = document.createElement("input");
    creationDateTextBox.className = "objectTextBox";
    creationDateTextBox.value = dateFormatter(addressObject.creation_date);
    creationDateTextBox.disabled = true;

    const modifiedDateTextLabel = document.createElement("label");
    modifiedDateTextLabel.className = "infoObjectLabel";
    modifiedDateTextLabel.innerText = "Modified date:";

    const modifiedDateTextBox = document.createElement("input");
    modifiedDateTextBox.className = "objectTextBox";
    modifiedDateTextBox.value = dateFormatter(addressObject.modified_date);
    modifiedDateTextBox.disabled = true;

    const editButton = document.createElement("button");
    editButton.className = "editObjectButton";
    editButton.innerText = "Edit";

    function fieldsDisabled (boolValue) {
        streetNameTextBox.disabled = boolValue;
        complementTextBox.disabled = boolValue;
        referenceTextBox.disabled = boolValue;
        districtTextBox.disabled = boolValue;
        cepTextBox.disabled = boolValue;
        numberTextBox.disabled = boolValue;
        descriptionTextBox.disabled = boolValue;
    }

    editButton.addEventListener("click", (t) => {
        if(editButton.innerHTML === "Edit") {
            editButton.innerText = "Save";
            fieldsDisabled(false);
            return;
        }

        if(editButton.innerHTML === "Save") {
            try {
                let newAddress = {
                    cep: cepTextBox.value,
                    complement: complementTextBox.value,
                    description: descriptionTextBox.value,
                    district: districtTextBox.value,
                    number: numberTextBox.value,
                    reference: referenceTextBox.value,
                    street_name: streetNameTextBox.value
                }
                putDB.execute(`${API.URL}put/addresses/${addressObject.client_addressId}`, newAddress);
            }
            catch(error) {
                console.log("ERROR Occurred - " + error);
            }

            editButton.innerText = "Edit";
            fieldsDisabled(true);
            setTimeout(() => {
                ipcRenderer.send("updateAllClients");
            }, 100); 
        }
    });

    cepTextBox.addEventListener("input", function(e) {
        let value = e.target.value.replace(/\D/g, '');
    
        if(value.length > 5) {
            value = value.slice(0,5) + "-" + value.slice(5);
        }
        e.target.value = value;
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
    div.appendChild(editButton);

    elementAddressesList.appendChild(div);
}

module.exports = {
    createPhoneObject,
    createAddressesObject
}