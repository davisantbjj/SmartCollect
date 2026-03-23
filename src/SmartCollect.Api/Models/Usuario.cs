namespace SmartCollect.Api.Models;

public class Usuario
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
    public string Role { get; set; } = "Operador";
    public bool Ativo { get; set; } = true;
    public DateTime? UltimoLogin { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Tenancy Tenant { get; set; } = null!;
    public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}