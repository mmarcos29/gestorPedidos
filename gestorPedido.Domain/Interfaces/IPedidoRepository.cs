using gestorPedido.Domain.Entities;

namespace gestorPedido.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        string Add(Pedido pedido);
    }
}
