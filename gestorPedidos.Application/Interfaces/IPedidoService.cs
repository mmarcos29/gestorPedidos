using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;

namespace gestorPedidos.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoResponseDto> CriarPedidoAsync(PedidoDto pedidoDto);
        Task<PedidoResponseDto?> ObterPedidoPorIdAsync(int id);
        Task<IEnumerable<PedidoResponseDto>> ListarPedidosAsync();
        Task<PedidoResponseDto> AtualizarPedidoAsync(int id, PedidoDto pedidoDto);
        Task ExcluirPedidoAsync(int id);
    }
}
