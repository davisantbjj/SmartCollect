namespace SmartCollect.Api.Models;

public class Tenancy
{
    public Guid Id { get; set; }
    public string NomeEmpresa { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string DominioEmail { get; set; } = string.Empty;
    public string? SmtpHost { get; set; }
    public int? SmtpPorta { get; set; }
    public string? SmtpUsuario { get; set; }
    public string? SmtpSenhaEncrypted { get; set; }
    public string? WhatsAppApiToken { get; set; }
    public string Plano { get; set; } = "Basic";
    public bool Ativo { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public ICollection<ReguaCobranca> Reguas { get; set; } = new List<ReguaCobranca>();
    public ICollection<ImportacaoArquivo> Importacoes { get; set; } = new List<ImportacaoArquivo>();
    public ICollection<TemplateMensagem> Templates { get; set; } = new List<TemplateMensagem>();
}