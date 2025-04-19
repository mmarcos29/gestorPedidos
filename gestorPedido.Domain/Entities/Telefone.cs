using System.ComponentModel.DataAnnotations;

public class Telefone
{
    public int Id { get; set; }

    [Required]
    public required string Ddd { get; set; }

    [Phone]
    public string? Numero { get; set; }

    public int ContatoId { get; set; }
    public Contato? Contato { get; set; }
}
