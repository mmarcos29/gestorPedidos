using gestorPedido.Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace gestorPedido.Domain.Entities
{
    [Index(nameof(Cnpj), IsUnique = true)]
    public class Revenda : BaseEntity
    {
        [Required]
        [MaxLength(18)]
        public required string Cnpj { get; set; }

        [Required]
        [MaxLength(100)]
        public required string RazaoSocial { get; set; }

        [Required]
        [MaxLength(100)]
        public required string NomeFantasia { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public ICollection<Contato> Contatos { get; set; } = new List<Contato>();
        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
