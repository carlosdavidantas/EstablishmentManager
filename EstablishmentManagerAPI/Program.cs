var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return "API working!";
});

app.MapGet("/database", () =>
{
    return "Done!";
});

app.Run();
