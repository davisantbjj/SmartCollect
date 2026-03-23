namespace SmartCollect.Api.Models;

public class Cliente
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public string RazaoSocial { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string? NomeFantasia { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Usuario Usuario { get; set; } = null!;
    public ICollection<Contato> Contatos { get; set; } = new List<Contato>();
    public ICollection<Titulo> Titulos { get; set; } = new List<Titulo>();
}