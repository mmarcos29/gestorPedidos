using gestorPedido.Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gestorPedido.Domain.Entities
{
    public class ItemPedido : BaseEntity
    {
        [ForeignKey("Pedido")]
        public int? PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [ForeignKey("PedidoDistribuidor")]
        public int? PedidoDistribuidorId { get; set; }
        [JsonIgnore]
        public PedidoDistribuidor? PedidoDistribuidor { get; set; }

        public int Quantidade { get; set; }
    }
}