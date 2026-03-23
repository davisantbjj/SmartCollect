namespace SmartCollect.Api.Models;

public class Gatilho
{
    public Guid Id { get; set; }
    public Guid ReguaId { get; set; }
    public Guid TemplateId { get; set; }
    public string Canal { get; set; } = "Email";
    public int DiasOffset { get; set; }
    public string Referencia { get; set; } = "Vencimento";
    public int Ordem { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ReguaCobranca Regua { get; set; } = null!;
    public TemplateMensagem Template { get; set; } = null!;
    public ICollection<Envio> Envios { get; set; } = new List<Envio>();
}