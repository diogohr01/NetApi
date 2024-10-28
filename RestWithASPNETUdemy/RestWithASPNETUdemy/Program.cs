using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuração do Entity Framework Core com PostgreSQL
var connection = builder.Configuration["PsqlConnection:PsqlConnectionString"];
builder.Services.AddDbContext<PsqlContext>(options => 
    options.UseNpgsql(connection));

// Injeção de dependências
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var app = builder.Build();

// Configure o pipeline de requisição HTTP
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
