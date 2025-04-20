using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using System.Collections.Generic;

namespace gestorPedidos.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private static Dictionary<string, Pedido> _pedidos = new Dictionary<string, Pedido>();

        public string Add(Pedido pedido)
        {
            var pedidoId = Guid.NewGuid().ToString();
            _pedidos[pedidoId] = pedido;
            return pedidoId;
        }
    }
}
