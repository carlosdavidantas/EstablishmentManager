async function execute(url){
    let success;
    await fetch(url, {
        method: "DELETE",
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })
    .then((response) => {
        if (response.ok) {
            success = true;
            console.log("Delete request sent!");
        } else {
            console.log("Error while trying to delete:", response.status);
            success = false;
        }
    })
    .catch((error) => {
        console.log("Unexpected error occurred:", error);
    });

    return success;
}

module.exports = { execute }
