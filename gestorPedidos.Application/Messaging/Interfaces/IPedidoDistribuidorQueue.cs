using gestorPedido.Domain.Entities;

namespace gestorPedidos.Application.Messaging.Interfaces
{
    public interface IPedidoDistribuidorQueue
    {
        Task EnfileirarAsync(PedidoDistribuidor pedido);
    }
}