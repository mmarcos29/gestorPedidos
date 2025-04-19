using gestorPedido.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Contato
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    public bool Principal { get; set; }

    [JsonIgnore]
    public int RevendaId { get; set; }

    [JsonIgnore]
    public Revenda? Revenda { get; set; }

    public List<Telefone> Telefones { get; set; } = new();
}