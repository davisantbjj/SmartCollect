using SmartCollect.Api.Models;

namespace SmartCollect.Api.Tests;

public class DomainDefaultsTests
{
    [Fact]
    public void Usuario_ShouldStartWithExpectedDefaults()
    {
        var usuario = new Usuario();

        Assert.Equal("Operador", usuario.Role);
        Assert.True(usuario.Ativo);
        Assert.NotEqual(default, usuario.CreatedAt);
        Assert.NotEqual(default, usuario.UpdatedAt);
    }

    [Fact]
    public void Contato_ShouldStartWithExpectedDefaults()
    {
        var contato = new Contato();

        Assert.Equal("Financeiro", contato.Setor);
        Assert.False(contato.Principal);
    }

    [Fact]
    public void Titulo_ShouldStartWithExpectedDefaults()
    {
        var titulo = new Titulo();

        Assert.Equal("Aberto", titulo.Status);
        Assert.NotEqual(default, titulo.CreatedAt);
        Assert.NotEqual(default, titulo.UpdatedAt);
    }
}
