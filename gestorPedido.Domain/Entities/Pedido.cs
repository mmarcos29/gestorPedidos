using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace gestorPedido.Domain.Entities
{
    public class Pedido
    {
        public string ClienteId { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }

    public class ItemPedido
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
    }
}

