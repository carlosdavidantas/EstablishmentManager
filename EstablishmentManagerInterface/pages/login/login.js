const postDB = require("../../scripts/postDB.js");
let API = require("../../scripts/API.js")
const postLoginURL = `${API.URL}login`;
const wrongLogin = document.getElementById("wrongLogin");

document.getElementById("passwordTextBox").addEventListener("keydown", async (keydownEvent) => {
    if(keydownEvent.key === "Enter"){
        const userInput = document.getElementById("userTextBox").value;
        const passwordInput = document.getElementById("passwordTextBox").value;
        let loginData = {
            Login: userInput,
            Password: passwordInput
        }
        const response = await postDB.execute(postLoginURL, loginData);
        if(response === true){
            location.href = "../home/home.html";
            wrongLogin.textContent = "";
        }
        else
        {
            wrongLogin.textContent = "Wrong user or password";
        }
        
    }
});
