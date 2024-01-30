async function get(url) {
    const response = await fetch(url);
    const information = await response.json();
    let responseAndInformationArray = [response, information];
    return responseAndInformationArray;
}

module.exports = { get }
