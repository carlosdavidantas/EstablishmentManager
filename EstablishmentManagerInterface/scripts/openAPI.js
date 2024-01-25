function execute() {
    const { spawn } = require('node:child_process'); 
    const exe = spawn('C:\\Projetos\\EstablishmentManager\\EstablishmentManagerAPI\\bin\\Release\\net8.0\\EstablishmentManagerAPI.exe'); 
    
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

module.exports = { execute };