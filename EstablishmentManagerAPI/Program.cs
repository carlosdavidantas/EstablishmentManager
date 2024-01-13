using EstablishmentManagerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Models.ClientRelated;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
AppDbContext context = new AppDbContext();


app.MapDelete("v1/delete/client", (int id) =>
{

});

app.MapGet("/v1/clients", () =>
{
    Client client = new Client("Teste", "658974125", DateTime.Now, "965874123", 50m, 0);

    Client_telephone first_telephone = new Client_telephone("980080808", "Telefone principal");
    first_telephone.Client = client;

    Client_telephone second_telephone = new Client_telephone("974368254", "Telefone secundário");
    second_telephone.Client = client;

    Client_telephone son_telephone = new Client_telephone("974368254", "Telefone filho");
    son_telephone.Client = client;

    Client_address primary_address = new Client_address("Rua x", "54987258", "Apartamento de 3 andares", 
        "Esquina com a rua Y", "1", "Endereço principal");
    primary_address.Client = client;

    Client_address work_address = new Client_address("Rua alpha", "98567270", "No shopping",
        "Em frente ao mercado", "5A", "Trabalho");
    work_address.Client = client;

    client.Client_telephones.Add(first_telephone);
    client.Client_telephones.Add(second_telephone);
    client.Client_telephones.Add(son_telephone);
    client.Client_addresses.Add(primary_address);
    client.Client_addresses.Add(work_address);

    context.Clients.Add(client);
    //context.Clients.Add(otherClient);
    context.SaveChanges();

    return context.Clients.ToList();
});

app.Run();
