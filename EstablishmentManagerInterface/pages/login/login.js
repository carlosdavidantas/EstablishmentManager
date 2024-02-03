const postDB = require("../../scripts/postDB.js");
let API = require("../../scripts/API.js")
const postLoginURL = `${API.URL}post/login`;
const loginStatus = document.getElementById("loginStatus");

document.getElementById("passwordTextBox").addEventListener("keydown", async (keydownEvent) => {
    if(keydownEvent.key === "Enter"){
        const userInput = document.getElementById("userTextBox").value;
        const passwordInput = document.getElementById("passwordTextBox").value;
        let loginData = {
            Login: userInput,
            Password: passwordInput
        }
        loginStatus.textContent = "Loading";
        const response = await postDB.execute(postLoginURL, loginData);
        if(response === true){
            location.href = "../home/home.html";
            loginStatus.textContent = "";
        }
        else
        {
            loginStatus.textContent = "Wrong user or password";
            setTimeout(() => {
                loginStatus.textContent = "";
            }, 1500);
        }
        
    }
});
