using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SmartCollect.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Env.TraversePath().Load();

var configuredConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionBuilder = new NpgsqlConnectionStringBuilder(
    string.IsNullOrWhiteSpace(configuredConnectionString)
        ? "Host=localhost;Port=55432;Database=smartcollect;Username=smartcollect"
        : configuredConnectionString);

var dbHost = Environment.GetEnvironmentVariable("POSTGRES_HOST")
    ?? Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("POSTGRES_PORT")
    ?? Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB")
    ?? Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER")
    ?? Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")
    ?? Environment.GetEnvironmentVariable("DB_PASSWORD");

if (!string.IsNullOrWhiteSpace(dbHost)) connectionBuilder.Host = dbHost;
if (int.TryParse(dbPort, out var parsedPort)) connectionBuilder.Port = parsedPort;
if (!string.IsNullOrWhiteSpace(dbName)) connectionBuilder.Database = dbName;
if (!string.IsNullOrWhiteSpace(dbUser)) connectionBuilder.Username = dbUser;
if (!string.IsNullOrWhiteSpace(dbPassword)) connectionBuilder.Password = dbPassword;

if (string.IsNullOrWhiteSpace(connectionBuilder.Password))
{
    throw new InvalidOperationException(
    "Database password is not configured. Set POSTGRES_PASSWORD (or DB_PASSWORD) in .env/environment, or set ConnectionStrings:DefaultConnection with Password.");
}

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