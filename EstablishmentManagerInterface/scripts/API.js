const { spawn } = require('node:child_process');
const apiPath = "C:\\Projetos\\EstablishmentManager\\EstablishmentManagerAPI\\bin\\Release\\net8.0\\EstablishmentManagerAPI.exe";
const URL = "http://localhost:5000/v1/";

function open() {
    const exe = spawn(apiPath); 
    
    exe.stdout.on('data', (data) => { 
        console.log(data.toString()); 
    }); 
    
    exe.stderr.on('data', (data) => { 
        console.error(data.toString()); 
    }); 
    
    exe.on('exit', (code) => { 
        console.log(`Child exited with code ${code}`); 
    }); 
}

module.exports = { open, URL }
