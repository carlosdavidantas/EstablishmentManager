async function execute(url) {
    const response = await fetch(url);
    const information = await response.json();
    let responseAndInformationArray = [response, information];
    return responseAndInformationArray;
}

module.exports = { execute }
