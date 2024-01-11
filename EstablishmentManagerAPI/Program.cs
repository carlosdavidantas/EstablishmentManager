using EstablishmentManagerLibrary.Database;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/database", () =>
{
    Database_setup.CreatDataBase();
    return "Created";
});

app.Run();
