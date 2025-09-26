using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "TestStrategies API", 
        Version = "v1",
        Description = "API de gestion de comptes bancaires pour exercices de tests"
    });
});
builder.Services.AddSingleton<TestStrategies.AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestStrategies API v1");
        c.RoutePrefix = string.Empty; // Pour accéder à Swagger UI à la racine
    });
}

app.UseHttpsRedirection();

// Créer un nouveau compte
app.MapPost("/accounts", (TestStrategies.AccountService service, CreateAccountRequest request) =>
{
    try
    {
        var acc = service.CreateAccount(request.Owner, request.InitialDeposit);
        return Results.Created($"/accounts/{acc.Id:D}", acc);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// Récupérer un compte par ID
app.MapGet("/accounts/{id}", (TestStrategies.AccountService service, Guid id) =>
{
    var acc = service.GetAccount(id);
    return acc is null ? Results.NotFound() : Results.Ok(acc);
});

// Récupérer tous les comptes
app.MapGet("/accounts", (TestStrategies.AccountService service) =>
{
    return Results.Ok(service.GetAllAccounts());
});

// Déposer de l'argent
app.MapPost("/accounts/{id}/deposit", (TestStrategies.AccountService service, Guid id, DepositRequest request) =>
{
    try
    {
        service.Deposit(id, request.Amount);
        var account = service.GetAccount(id);
        return Results.Ok(account);
    }
    catch (KeyNotFoundException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// Retirer de l'argent
app.MapPost("/accounts/{id}/withdraw", (TestStrategies.AccountService service, Guid id, WithdrawRequest request) =>
{
    try
    {
        service.Withdraw(id, request.Amount);
        var account = service.GetAccount(id);
        return Results.Ok(account);
    }
    catch (KeyNotFoundException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// Calculer les intérêts
app.MapGet("/accounts/{id}/interest", (TestStrategies.AccountService service, Guid id) =>
{
    var acc = service.GetAccount(id);
    if (acc is null) return Results.NotFound();
    return Results.Ok(new { Interest = acc.CalculateInterest() });
});

app.Run();

// DTOs pour les requêtes
public record CreateAccountRequest(string Owner, decimal InitialDeposit = 0);
public record DepositRequest(decimal Amount);
public record WithdrawRequest(decimal Amount);

// Rendre Program accessible pour les tests
public partial class Program { }
