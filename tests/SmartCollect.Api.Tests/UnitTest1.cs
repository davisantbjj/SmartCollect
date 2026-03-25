using Microsoft.EntityFrameworkCore;
using SmartCollect.Api.Data;
using SmartCollect.Api.Models;

namespace SmartCollect.Api.Tests;

public class AppDbContextModelConfigurationTests
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void OnModelCreating_ShouldConfigureUniqueIndexes()
    {
        using var context = CreateContext();
        var model = context.Model;

        var tenancyIndexes = model.FindEntityType(typeof(Tenancy))!.GetIndexes();
        var usuarioIndexes = model.FindEntityType(typeof(Usuario))!.GetIndexes();
        var clienteIndexes = model.FindEntityType(typeof(Cliente))!.GetIndexes();
        var tituloIndexes = model.FindEntityType(typeof(Titulo))!.GetIndexes();

        Assert.Contains(tenancyIndexes, i =>
            i.IsUnique && i.Properties.Select(p => p.Name).SequenceEqual([nameof(Tenancy.Cnpj)]));
        Assert.Contains(usuarioIndexes, i =>
            i.IsUnique && i.Properties.Select(p => p.Name).SequenceEqual([nameof(Usuario.Email)]));
        Assert.Contains(clienteIndexes, i =>
            i.IsUnique && i.Properties.Select(p => p.Name).SequenceEqual([nameof(Cliente.Cnpj)]));
        Assert.Contains(tituloIndexes, i =>
            i.IsUnique && i.Properties.Select(p => p.Name).SequenceEqual([nameof(Titulo.CodigoUnico)]));
    }

    [Fact]
    public void OnModelCreating_ShouldConfigureTituloValorPrecision()
    {
        using var context = CreateContext();
        var valorProperty = context.Model
            .FindEntityType(typeof(Titulo))!
            .FindProperty(nameof(Titulo.Valor));

        Assert.NotNull(valorProperty);
        Assert.Equal(18, valorProperty!.GetPrecision());
        Assert.Equal(2, valorProperty.GetScale());
    }
}
