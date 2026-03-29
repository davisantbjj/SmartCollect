using Microsoft.EntityFrameworkCore;
using SmartCollect.Api.Models;

namespace SmartCollect.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tenancy> Tenancies { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Titulo> Titulos { get; set; }
    public DbSet<ImportacaoArquivo> ImportacoesArquivo { get; set; }
    public DbSet<Ocorrencia> Ocorrencias { get; set; }
    public DbSet<ReguaCobranca> ReguasCobranca { get; set; }
    public DbSet<Gatilho> Gatilhos { get; set; }
    public DbSet<TemplateMensagem> TemplatesMensagem { get; set; }
    public DbSet<Envio> Envios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tenancy>(e => {
            e.HasIndex(t => t.Cnpj).IsUnique();
        });

        modelBuilder.Entity<Usuario>(e => {
            e.HasIndex(u => new { u.TenantId, u.Email }).IsUnique();
        });

        modelBuilder.Entity<Cliente>(e => {
            e.HasIndex(c => new { c.TenantId, c.Cnpj }).IsUnique();
        });

        modelBuilder.Entity<Titulo>(e => {
            e.HasIndex(t => new { t.TenantId, t.CodigoUnico }).IsUnique();
            e.Property(t => t.Valor).HasPrecision(18, 2);
        });
    }
}