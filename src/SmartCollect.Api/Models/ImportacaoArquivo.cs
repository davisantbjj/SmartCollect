namespace SmartCollect.Api.Models;

public class ImportacaoArquivo
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string NomeArquivo { get; set; } = string.Empty;
    public string Tipo { get; set; } = "Excel";
    public string Status { get; set; } = "Processando";
    public int TotalLinhas { get; set; }
    public int LinhasSucesso { get; set; }
    public int LinhasErro { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Tenancy Tenant { get; set; } = null!;
    public ICollection<Titulo> Titulos { get; set; } = new List<Titulo>();
}