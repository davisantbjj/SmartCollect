namespace SmartCollect.Api.Models;

public class ReguaCobranca
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public bool Ativa { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Tenancy Tenant { get; set; } = null!;
    public ICollection<Gatilho> Gatilhos { get; set; } = new List<Gatilho>();
}