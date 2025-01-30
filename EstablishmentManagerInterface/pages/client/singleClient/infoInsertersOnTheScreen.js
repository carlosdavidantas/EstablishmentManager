function insertClientBasicInfomation(clientPrimaryInfos, ...elements) {
    for(const element of elements){
        element.value = clientPrimaryInfos[element.id];
    }
}

function clientFieldsDisabled (boolValue, elementsArray) {
    for(const element of elementsArray){
        element.disabled = boolValue;
    }
}


module.exports = {
    insertClientBasicInfomation,
    clientFieldsDisabled
}