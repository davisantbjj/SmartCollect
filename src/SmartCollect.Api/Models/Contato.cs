namespace SmartCollect.Api.Models;

public class Contato
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? TelefoneWhatsApp { get; set; }
    public string Setor { get; set; } = "Financeiro";
    public bool Principal { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Cliente Cliente { get; set; } = null!;
    public ICollection<Envio> Envios { get; set; } = new List<Envio>();
}