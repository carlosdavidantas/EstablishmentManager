using EstablishmentManagerAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Models.ClientRelated;
using Models.UserRelated;
using System;
using System.Net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

//Configure Json to handle cycle.
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>
    (options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();
 
void SettingTest(AppDbContext context)
{
    Client client = new Client("Teste2", "847542364", DateOnly.Parse("14/01/2024"), "945783513", 125.75m, 0);

    Client_telephone first_telephone = new Client_telephone("268536953", "Telefone principal");
    first_telephone.Client = client;

    Client_telephone second_telephone = new Client_telephone("986832394", "Telefone secundário");
    second_telephone.Client = client;

    Client_telephone son_telephone = new Client_telephone("982366157", "Telefone filho");
    son_telephone.Client = client;

    Client_address primary_address = new Client_address("Rua m", "Novo Bairro", "98261422", "Apartamento de 8 andares",
        "Esquina com a rua K", "8", "Endereço principal");
    primary_address.Client = client;

    Client_address work_address = new Client_address("Rua delta", "Novo Bairro", "89815543", "No shopping",
        "Em frente ao mercado", "7m", "Trabalho");
    work_address.Client = client;

    client.Client_telephones.Add(first_telephone);
    client.Client_telephones.Add(second_telephone);
    client.Client_telephones.Add(son_telephone);
    client.Client_addresses.Add(primary_address);
    client.Client_addresses.Add(work_address);

    context.Clients.Add(client);
    context.SaveChanges();
}

//Clients routes
//Return every client with telephones and addresses info.
app.MapGet("/v1/get/clients/", async (AppDbContext context) =>
{
    var clientsFoundList = await context.Clients
    .Include(client => client.Client_telephones)
    .Include(client => client.Client_addresses)
    .ToListAsync();

    if (clientsFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(clientsFoundList);

});

//Search by a client prop and return a client object with telephones and addresses info.
app.MapGet("/v1/get/clients/{search}", async (string search, AppDbContext context) =>
{
    DateOnly birth;
    int idResult;

    bool convertDate = DateOnly.TryParse(search, out birth);
    bool convertId = int.TryParse(search, out idResult);

    var clientsFoundList = await context.Clients
        .Include(client => client.Client_telephones)
        .Include(client => client.Client_addresses)
        .Where(client => client.ClientId == idResult
        || client.Birthday == birth || client.Name == search || client.Cpf == search || client.Rg == search).ToListAsync();

    if(clientsFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(clientsFoundList);
});

app.MapPost("v1/post/clients", async (Client sentClient, AppDbContext context) =>
{
    Console.WriteLine("My client - " + sentClient);
    sentClient.Creation_date = DateOnly.FromDateTime(DateTime.Today);
    sentClient.Modified_date = DateOnly.FromDateTime(DateTime.Today);

    foreach (var address in sentClient.Client_addresses)
    {
        Console.WriteLine("Address - " + address);
        address.Creation_date = DateOnly.FromDateTime(DateTime.Today);
        address.Modified_date = DateOnly.FromDateTime(DateTime.Today);
    }

    foreach (var telephone in sentClient.Client_telephones)
    {
        Console.WriteLine("Telephone - " + telephone);
        telephone.Creation_date = DateOnly.FromDateTime(DateTime.Today);
        telephone.Modified_date = DateOnly.FromDateTime(DateTime.Today);
    }

    await context.Clients.AddAsync(sentClient);
    await context.SaveChangesAsync();
    return Results.Created($"v1/post/clients/{sentClient.ClientId}", sentClient);
});

app.MapPut("v1/put/clients/{id}", async (int id, Client inputClient, AppDbContext context) =>
{
    var client = await context.Clients.FindAsync(id);
    if (client == null)
        return Results.NotFound();

    client.Birthday = inputClient.Birthday;
    client.Cpf = inputClient.Cpf;
    client.Credit_on_establishment = inputClient.Credit_on_establishment;
    client.Debit_on_establishment = inputClient.Debit_on_establishment;
    client.Modified_date = DateOnly.FromDateTime(DateTime.Today);
    client.Name = inputClient.Name;
    client.Rg = inputClient.Rg;

    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapDelete("v1/delete/clients/{id}", async (int id, AppDbContext context) =>
{
    if(await context.Clients.FindAsync(id) is Client client)
    {
        context.Clients.Remove(client);
        await context.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

//Telephones routes.
//Return every telephones with a client object.
app.MapGet("v1/get/telephones", async (AppDbContext context) =>
{
    var telephonesFoundList = await context.Client_Telephones
        .Include(telephone => telephone.Client).ToListAsync();

    if (telephonesFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(telephonesFoundList);
});

//Search by a telephone prop and return it with a client object.
app.MapGet("v1/get/telephones/{search}", async (string search, AppDbContext context) =>
{
    int idResult;
    bool convertId = int.TryParse(search, out idResult);

    var telephonesFoundList = await context.Client_Telephones
        .Include(telephone => telephone.Client)
        .Where(telephone => telephone.Client_telephoneId == idResult
        || telephone.Number == search).ToListAsync();

    if (telephonesFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(telephonesFoundList);
});

//Update a specific telephone by the id of it
app.MapPut("v1/put/telephone/{id}", async (int id, Client_telephone inputTelephone, AppDbContext context) =>
{
    var telephone = await context.Client_Telephones.FindAsync(id);
    if (telephone == null)
        return Results.NotFound();

    telephone.Description = inputTelephone.Description;
    telephone.Number = inputTelephone.Number;
    telephone.Modified_date = DateOnly.FromDateTime(DateTime.Today);

    await context.SaveChangesAsync();
    return Results.Ok();
});

//Addresses routes
//Return every address with a client object.
app.MapGet("v1/get/addresses", async (AppDbContext context) =>
{
    var addressFoundList = await context.Client_Addresses
        .Include(address => address.Client).ToListAsync();

    if (addressFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(addressFoundList);
});

//Search by a address prop and return it with a client object.
app.MapGet("v1/get/addresses/{search}", async (string search, AppDbContext context) =>
{
    int idResult;
    bool convertId = int.TryParse(search, out idResult);

    var addressesFoundList = await context.Client_Addresses
        .Include(address => address.Client)
        .Where(address => address.Client_addressId == idResult
        || address.Cep == search || address.Description == search || address.Street_name == search).ToListAsync();

    if (addressesFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(addressesFoundList);
});

app.MapPut("v1/put/addresses/{id}", async (int id, Client_address  inputAddress, AppDbContext context) =>
{
    var address = await context.Client_Addresses.FindAsync(id);
    if (address == null)
        return Results.NotFound();

    address.Cep = inputAddress.Cep;
    address.Complement = inputAddress.Complement;
    address.Description = inputAddress.Description;
    address.District = inputAddress.District;
    address.Number = inputAddress.Number;
    address.Reference = inputAddress.Reference;
    address.Street_name = inputAddress.Street_name;
    address.Modified_date = DateOnly.FromDateTime(DateTime.Today);

    await context.SaveChangesAsync();
    return Results.Ok();
});

//Group of products routes
//Return every group of product with the products.
app.MapGet("v1/get/group-of-product/", async (AppDbContext context) =>
{
    var groupOfProductFoundList = await context.Group_of_products
    .Include(groupOfProduct => groupOfProduct.Products)
    .ToListAsync();

    if (groupOfProductFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(groupOfProductFoundList);

});

//Search by a group of product prop and return with products object.
app.MapGet("v1/get/group-of-product/{search}", async (string search, AppDbContext context) =>
{
    int idResult;
    bool convertId = int.TryParse(search, out idResult);

    var groupOfProductFoundList = await context.Group_of_products
        .Include(groupOfProduct => groupOfProduct.Products)
        .Where(groupOfProduct => groupOfProduct.Group_of_productId == idResult
        || groupOfProduct.Category == search || groupOfProduct.Name == search).ToListAsync();

    if (groupOfProductFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(groupOfProductFoundList);
});

//Products route
//Return every product with addons and observations options.
app.MapGet("v1/get/products/", async (AppDbContext context) =>
{
    var productFoundList = await context.Products
    .Include(product => product.Product_addons)
    .Include(product => product.Product_observations)
    .ToListAsync();

    if (productFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(productFoundList);

});

//Search by a product prop and return it with addons and observations options.
app.MapGet("v1/get/products/{search}", async (string search, AppDbContext context) =>
{
    int idResult;
    bool convertId = int.TryParse(search, out idResult);

    var productFoundList = await context.Products
        .Include(product => product.Product_addons)
        .Include(product => product.Product_observations)
        .Where(product => product.ProductId == idResult
        || product.Name == search || product.Category == search).ToListAsync();

    if (productFoundList.Count == 0)
    {
        return Results.NoContent();
    }
    return Results.Ok(productFoundList);
});

//User routes
//Route that verify the login sent.
app.MapPost("v1/post/login", async (User userSent, AppDbContext context) =>
{
    var userFoundList = await context.Users.ToListAsync();
    if (userFoundList.Count == 0)
        return Results.NoContent();

    foreach (var user in userFoundList)
    {
        if (user.Login == userSent.Login && user.Password == userSent.Password)
            return Results.Ok(user);
    }

    return Results.NotFound();
});



app.Run();
