using Microsoft.EntityFrameworkCore;
using Npgsql;
using SmartCollect.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuredConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionBuilder = new NpgsqlConnectionStringBuilder(
    string.IsNullOrWhiteSpace(configuredConnectionString)
        ? "Host=localhost;Port=55432;Database=smartcollect;Username=smartcollect;Password=smart2026"
        : configuredConnectionString);

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

if (!string.IsNullOrWhiteSpace(dbHost)) connectionBuilder.Host = dbHost;
if (int.TryParse(dbPort, out var parsedPort)) connectionBuilder.Port = parsedPort;
if (!string.IsNullOrWhiteSpace(dbName)) connectionBuilder.Database = dbName;
if (!string.IsNullOrWhiteSpace(dbUser)) connectionBuilder.Username = dbUser;
if (!string.IsNullOrWhiteSpace(dbPassword)) connectionBuilder.Password = dbPassword;

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