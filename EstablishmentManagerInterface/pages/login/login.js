const postDB = require("../../scripts/postDB.js");
let API = require("../../scripts/API.js")
const postLoginURL = `${API.URL}post/login`;
const loginStatus = document.getElementById("loginStatus");
const passwordOpenEyeIconPath = "../../icons/openEye.svg";
const passwordEyeSlashIconPath = "../../icons/eyeSlash.svg";
const eyeIcon = document.getElementById("eyeIcon");

document.getElementById("passwordTextBox").addEventListener("keydown", async (keydownEvent) => {
    if(keydownEvent.key === "Enter"){
        await connect();
    }
});

document.getElementById("loginButton").addEventListener("click", async () => {
    await connect();
})

let isVisible = false;
document.getElementById("viewPasswordButton").addEventListener("click", () => {
    if(isVisible == false) {
        eyeIcon.src = passwordOpenEyeIconPath;
        document.getElementById("passwordTextBox").type = "text";
        isVisible = true;
    }
    else {
        eyeIcon.src = passwordEyeSlashIconPath;
        document.getElementById("passwordTextBox").type = "password";
        isVisible = false;
    }
})

document.getElementById("passwordTextBox").addEventListener("mouseover", (event) => {
    eyeIcon.src = passwordOpenEyeIconPath;
    document.getElementById("passwordTextBox").type = "text";
    setTimeout(() => {
        eyeIcon.src = passwordEyeSlashIconPath;
        document.getElementById("passwordTextBox").type = "password";
    }, 500);
});

async function connect() {
    const userInput = document.getElementById("userTextBox").value;
    const passwordInput = document.getElementById("passwordTextBox").value;
    let loginData = {
        Login: userInput,
        Password: passwordInput
    };
    loginStatus.textContent = "Loading";
    const response = await postDB.execute(postLoginURL, loginData);
    if (response === true) {
        location.href = "../home/home.html";
        loginStatus.textContent = "";
    }

    else {
        loginStatus.textContent = "Wrong user or password";
        setTimeout(() => {
            loginStatus.textContent = "";
        }, 1500);
    }
}
