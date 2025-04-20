using gestorPedido.Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestorPedido.Domain.Entities
{
    public class ItemPedido : BaseEntity
    {
        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
