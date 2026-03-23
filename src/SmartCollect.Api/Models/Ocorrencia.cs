namespace SmartCollect.Api.Models;

public class Ocorrencia
{
    public Guid Id { get; set; }
    public Guid TituloId { get; set; }
    public string StatusAtualizado { get; set; } = string.Empty;
    public DateTime DataOcorrencia { get; set; }
    public DateTime ProcessadoEm { get; set; } = DateTime.UtcNow;
    public bool AgradecimentoEnviado { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Titulo Titulo { get; set; } = null!;
}