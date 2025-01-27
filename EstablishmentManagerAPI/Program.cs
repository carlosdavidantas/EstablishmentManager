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


// This function validates if the client has a name, phone number and street name address.
static IResult ClientValidation(Client client)
{
    string clientName = client.Name.Trim();
    if (clientName.Length == 0 || clientName == null)
        return Results.BadRequest("Client must have a name.");

    string clientTelephone = client.Client_telephones.First().Number.Trim();
    if (clientTelephone.Length == 0 || clientTelephone == null)
        return Results.BadRequest("Client must have at least one phone number.");

    string clientAdddress = client.Client_addresses.First().Street_name.Trim();
    if (clientAdddress.Length == 0 || clientAdddress == null)
        return Results.BadRequest("Client must have at least one street name addressed.");

    return Results.Ok();
}
 

//Clients routes.
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

//Search by a client id and return a client object with telephones and addresses info.
app.MapGet("/v1/get/client/{search}", async (string search, AppDbContext context) =>
{
  
    int idResult;
    bool convertId = int.TryParse(search, out idResult);

    var clientsFoundList = await context.Clients
        .Include(client => client.Client_telephones)
        .Include(client => client.Client_addresses)
        .Where(client => client.ClientId == idResult).ToListAsync();

    if(clientsFoundList.Count == 0)
        return Results.NoContent();
    
    return Results.Ok(clientsFoundList);
});

app.MapPost("v1/post/client", async (Client sentClient, AppDbContext context) =>
{
    // Validades the client passed and returns 400 if there was something wrong with the client data.
    IResult validation = ClientValidation(sentClient);
    if(validation != Results.Ok()) 
    { 
        return validation; 
    }

    sentClient.Creation_date = DateOnly.FromDateTime(DateTime.Today);
    sentClient.Modified_date = DateOnly.FromDateTime(DateTime.Today);

    foreach (var address in sentClient.Client_addresses)
    {
        address.Creation_date = DateOnly.FromDateTime(DateTime.Today);
        address.Modified_date = DateOnly.FromDateTime(DateTime.Today);
    }

    foreach (var telephone in sentClient.Client_telephones)
    {
        telephone.Creation_date = DateOnly.FromDateTime(DateTime.Today);
        telephone.Modified_date = DateOnly.FromDateTime(DateTime.Today);
    }

    await context.Clients.AddAsync(sentClient);
    await context.SaveChangesAsync();
    return Results.Created($"v1/post/clients/{sentClient.ClientId}", sentClient);
});

app.MapPut("v1/put/client/{id}", async (int id, Client inputClient, AppDbContext context) =>
{
    var client = await context.Clients.FindAsync(id);
    if (client == null)
        return Results.NotFound("The id passed does not contain any client associate");

    // Validades the client passed and returns 400 if there was something wrong with the client data.
    string clientName = inputClient.Name.Trim();
    if (clientName.Length == 0 || clientName == null)
    {
        return Results.BadRequest("Client must have a correct name");
    }

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

app.MapDelete("v1/delete/client/{id}", async (int id, AppDbContext context) =>
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

app.MapDelete("v1/delete/telephone/{id}", async (int id, AppDbContext context) =>
{
    if(await context.Client_Telephones.FindAsync(id) is Client_telephone telephone)
    {
        context.Client_Telephones.Remove(telephone);
        await context.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
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
