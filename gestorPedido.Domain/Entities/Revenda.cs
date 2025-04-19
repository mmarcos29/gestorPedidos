using gestorPedido.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Revenda
{
    public int Id { get; set; }

    [Required]
    public required string Cnpj { get; set; }

    [Required]
    public required string RazaoSocial { get; set; }

    [Required]
    public required string NomeFantasia { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    public List<Contato> Contatos { get; set; } = new();
    public List<Endereco> Enderecos { get; set; } = new();
}
