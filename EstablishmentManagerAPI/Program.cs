using EstablishmentManagerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Models.ClientRelated;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();


app.MapGet("/v1/clients/", async (AppDbContext context) =>
{
    var clientsFoundList = await context.Clients.ToListAsync();
    if (clientsFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(clientsFoundList);

});

app.MapGet("/v1/clients/{search}", async (string search, AppDbContext context) =>
{
    var clientsFoundList = await context.Clients.Where(client => client.ClientId == int.Parse(search)
    || client.Name == search || client.Cpf == search).ToListAsync();

    if(clientsFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(clientsFoundList);
});

app.Run();


//Client client = new Client("Teste", "658974125", DateTime.Now, "965874123", 50m, 0);

//Client_telephone first_telephone = new Client_telephone("980080808", "Telefone principal");
//first_telephone.Client = client;

//Client_telephone second_telephone = new Client_telephone("974368254", "Telefone secundário");
//second_telephone.Client = client;

//Client_telephone son_telephone = new Client_telephone("974368254", "Telefone filho");
//son_telephone.Client = client;

//Client_address primary_address = new Client_address("Rua x", "54987258", "Apartamento de 3 andares", 
//    "Esquina com a rua Y", "1", "Endereço principal");
//primary_address.Client = client;

//Client_address work_address = new Client_address("Rua alpha", "98567270", "No shopping",
//    "Em frente ao mercado", "5A", "Trabalho");
//work_address.Client = client;

//client.Client_telephones.Add(first_telephone);
//client.Client_telephones.Add(second_telephone);
//client.Client_telephones.Add(son_telephone);
//client.Client_addresses.Add(primary_address);
//client.Client_addresses.Add(work_address);

//context.Clients.Add(client);
//context.SaveChanges();

//return context.Clients.ToList();