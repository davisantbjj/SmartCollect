namespace SmartCollect.Api.Models;

public class Titulo
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid? ImportacaoId { get; set; }
    public string CodigoUnico { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataEmissao { get; set; }
    public string? LinkBoleto { get; set; }
    public string Status { get; set; } = "Aberto";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Cliente Cliente { get; set; } = null!;
    public ImportacaoArquivo? Importacao { get; set; }
    public ICollection<Ocorrencia> Ocorrencias { get; set; } = new List<Ocorrencia>();
    public ICollection<Envio> Envios { get; set; } = new List<Envio>();
}