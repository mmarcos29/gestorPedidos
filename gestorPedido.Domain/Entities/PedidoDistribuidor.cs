using gestorPedido.Domain.Entities.Abstracts;
using gestorPedido.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestorPedido.Domain.Entities
{
    public class PedidoDistribuidor : BaseEntity
    {
        [ForeignKey("Revenda")]
        public int RevendaId { get; set; }
        public Revenda? Revenda { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        public bool Sucesso { get; set; }

        public string Retorno { get; set; }

        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

        [Required]
        public StatusPedidoDistribuidor Status { get; set; } = StatusPedidoDistribuidor.Pendente;
    }
}
