using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Enums;

namespace gestorPedido.Domain.Interfaces
{
    public interface IPedidoDistribuidorRepository
    {
        Task<PedidoDistribuidor?> ObterPedidoDistribuidorPorIdAsync(int id);
        Task<IEnumerable<PedidoDistribuidor>> ListarPedidosAsync();
        Task AdicionarPedidoAsync(PedidoDistribuidor pedidoDistribuidor);
        Task<IEnumerable<PedidoDistribuidor>> ObterConcluidosAsync();
        Task<IEnumerable<PedidoDistribuidor>> ObterPendentesAsync();
        Task AtualizarPedidoDistribuidorAsync(PedidoDistribuidor pedidoDistribuidor);
    }
}
