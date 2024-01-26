async function get(url) {
    const response = await fetch(url);
    const information = await response.json();
    console.log(information);
}

module.exports = { get };