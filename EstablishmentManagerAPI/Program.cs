using EstablishmentManagerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Models.ClientRelated;
using Models.UserRelated;
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

    Client_telephone second_telephone = new Client_telephone("986832394", "Telefone secund�rio");
    second_telephone.Client = client;

    Client_telephone son_telephone = new Client_telephone("982366157", "Telefone filho");
    son_telephone.Client = client;

    Client_address primary_address = new Client_address("Rua m", "98261422", "Apartamento de 8 andares",
        "Esquina com a rua K", "8", "Endere�o principal");
    primary_address.Client = client;

    Client_address work_address = new Client_address("Rua delta", "89815543", "No shopping",
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

//Client routes

//Return every client with telephones and addresses info.
app.MapGet("/v1/clients/", async (AppDbContext context) =>
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
app.MapGet("/v1/clients/{search}", async (string search, AppDbContext context) =>
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

//Return every telephones with a client object.
app.MapGet("/v1/telephones", async (AppDbContext context) =>
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
app.MapGet("/v1/telephones/{search}", async (string search, AppDbContext context) =>
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

//Return every address with a client object.
app.MapGet("/v1/addresses", async (AppDbContext context) =>
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
app.MapGet("/v1/addresses/{search}", async (string search, AppDbContext context) =>
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

//Return every group of product with the products.
app.MapGet("/v1/group-of-product/", async (AppDbContext context) =>
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
app.MapGet("/v1/group-of-product/{search}", async (string search, AppDbContext context) =>
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

//Return every product with addons and observations options.
app.MapGet("/v1/products/", async (AppDbContext context) =>
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
app.MapGet("/v1/products/{search}", async (string search, AppDbContext context) =>
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
app.MapGet("v1/user", async (User userSent, AppDbContext context) =>
{
    var userFound = await context.Users
    .Where(user => user.UserId == userSent.UserId && user.Password == userSent.Password).ToListAsync();

    if(userFound.Count == 0)
        return Results.NoContent();

    return Results.Ok(userFound);
});





app.Run();
