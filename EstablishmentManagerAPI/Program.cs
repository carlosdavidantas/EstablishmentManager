using EstablishmentManagerLibrary.Client_related;
using EstablishmentManagerLibrary.Database;
using EstablishmentManagerLibrary.Database.CRUD;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/database", () =>
{
    Delete.Client("1");
    return Select.Client("1");
});

app.Run();
