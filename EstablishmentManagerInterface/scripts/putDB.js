async function execute(url, object){
    let success;
    await fetch(url, {
        method: "PUT",
        body: JSON.stringify(object),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })
    .then((response) => {
        if (response.ok) {
            success = true;
            console.log("Put request sent!");
        } else {
            console.log("Error while sending the Put request:", response.status);
            success = false;
        }
    })
    .catch((error) => {
        console.log("Unexpected error occurred:", error);
    });

    return success;
}

module.exports = { execute }
