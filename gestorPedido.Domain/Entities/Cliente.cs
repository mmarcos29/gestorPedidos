using gestorPedido.Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestorPedido.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        [Required]
        public required string Cpf { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public List<Contato> Contatos { get; set; } = new();
        public List<Endereco> Enderecos { get; set; } = new();

        [Required]
        [ForeignKey("Revenda")]
        public int RevendaId { get; set; }
        public Revenda? Revenda { get; set; }

        public List<Pedido>? Pedidos { get; set; }
    }
}
