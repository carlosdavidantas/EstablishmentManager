using EstablishmentManagerLibrary.Database;
using EstablishmentManagerLibrary.Database.CRUD;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return Select.Client("1");
});

app.Run();
