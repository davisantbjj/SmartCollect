using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SmartCollect.Api.Data;

// Carrega variáveis de ambiente do arquivo .env na raiz do projeto
DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
var dbPort = int.Parse(Environment.GetEnvironmentVariable("DB_PORT") ?? "55432");
var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "smartcollect";
var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "smartcollect";
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "smart2026";

var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";
var connectionBuilder = new NpgsqlConnectionStringBuilder(connectionString);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionBuilder.ConnectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();