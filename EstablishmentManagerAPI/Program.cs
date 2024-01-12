using EstablishmentManagerLibrary.Database;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return "API working!";
});

app.MapGet("/database", () =>
{
    Database_setup.CreatDataBase();
    return "Done!";
});

app.Run();
