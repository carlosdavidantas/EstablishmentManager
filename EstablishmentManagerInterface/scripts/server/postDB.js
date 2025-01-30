async function execute(url, object){
    let success;
    await fetch(url, {
        method: "POST",
        body: JSON.stringify(object),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })
    .then((response) => {
        if (response.ok) {
            success = true;
            console.log("Post request sent!");
        } else {
            console.log("Error while sending the POST request:", response.status);
            success = false;
        }
    })
    .catch((error) => {
        console.log("Unexpected error occurred:", error);
    });

    return success;
}

module.exports = { execute }
