using gestorPedido.Domain.Entities;

namespace gestorPedido.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido?> ObterPedidoPorIdAsync(int id);
        Task<IEnumerable<Pedido>> ListarPedidosAsync();
        Task AdicionarPedidoAsync(Pedido pedido);
        Task AtualizarPedidoAsync(Pedido pedido);
    }
}
