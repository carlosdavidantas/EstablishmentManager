using EstablishmentManagerLibrary.ClientRelated;
using EstablishmentManagerLibrary.Database;
using EstablishmentManagerLibrary.Database.CRUD;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return "API working!";
});

app.MapGet("/database", () =>
{
    Database_setup.CreatDataBase();
    Client client = new Client("NomeTeste", "14758748954", DateTime.Now, "147852354", 0, 50);
    var myclient = Select.Client(client);
    Client_address client_address = new Client_address();
    
    return "Done!";
});

app.Run();
