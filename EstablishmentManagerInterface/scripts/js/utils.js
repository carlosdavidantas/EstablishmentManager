function dateFormatter(date) {
    const day = date.slice(8, 10);
    const month = date.slice(5, 7);
    const year = date.slice(0, 4);
    return `${day}/${month}/${year}`
}

function birthdayTypingMask(inputParameter) {
    let value = inputParameter.target.value.replace(/\D/g, '');
    
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
    return value;
}

function cpfTypingMask(inputParameter) {
    let value = inputParameter.target.value.replace(/\D/g, '');
    
    if(value.length > 3) {
        value = value.slice(0,3) + "." + value.slice(3);
    }

    if(value.length > 7){
        value = value.slice(0, 7) + "." + value.slice(7);
    }
    if(value.length > 11){
        value = value.slice(0, 11) + "-" + value.slice(11);
    }
    return value;
}

module.exports = {
    dateFormatter,
    birthdayTypingMask,
    cpfTypingMask
};
