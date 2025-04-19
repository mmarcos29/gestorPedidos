using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Telefone
{
    public int Id { get; set; }

    [Required]
    public required string Ddd { get; set; }

    [Phone]
    public string? Numero { get; set; }

    [JsonIgnore]
    public int ContatoId { get; set; }

    [JsonIgnore]
    public Contato? Contato { get; set; }
}
