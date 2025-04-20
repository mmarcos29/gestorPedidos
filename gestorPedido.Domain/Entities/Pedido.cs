using gestorPedido.Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestorPedido.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        [ForeignKey("Cliente")]
        public required int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("Revenda")]
        public int RevendaId { get; set; }
        public Revenda? Revenda { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.UtcNow;

        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }
}