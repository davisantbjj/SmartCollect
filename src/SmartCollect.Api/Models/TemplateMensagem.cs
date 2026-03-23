namespace SmartCollect.Api.Models;

public class TemplateMensagem
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Canal { get; set; } = "Email";
    public string? Assunto { get; set; }
    public string Corpo { get; set; } = string.Empty;
    public string Tipo { get; set; } = "Cobranca";
    public bool Ativo { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Tenancy Tenant { get; set; } = null!;
    public ICollection<Gatilho> Gatilhos { get; set; } = new List<Gatilho>();
}