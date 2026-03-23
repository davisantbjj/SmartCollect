namespace SmartCollect.Api.Models;

public class Envio
{
    public Guid Id { get; set; }
    public Guid TituloId { get; set; }
    public Guid ContatoId { get; set; }
    public Guid GatilhoId { get; set; }
    public string Canal { get; set; } = "Email";
    public string Status { get; set; } = "Pendente";
    public DateTime AgendadoPara { get; set; }
    public DateTime? EnviadoEm { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Titulo Titulo { get; set; } = null!;
    public Contato Contato { get; set; } = null!;
    public Gatilho Gatilho { get; set; } = null!;
}