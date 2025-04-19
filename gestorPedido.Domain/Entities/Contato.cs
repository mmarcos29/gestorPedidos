using gestorPedido.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Contato
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    public bool Principal { get; set; }

    public int RevendaId { get; set; }
    public Revenda Revenda { get; set; }

    public List<Telefone> Telefones { get; set; } = new();
}