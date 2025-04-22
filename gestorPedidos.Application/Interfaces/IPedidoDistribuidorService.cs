using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;

namespace gestorPedidos.Application.Interfaces
{
    public interface IPedidoDistribuidorService
    {
        Task<PedidoDistribuidorResponseDto> CriarPedidoAsync(PedidoDistribuidorDto pedidoDto);
        Task<PedidoDistribuidorResponseDto?> ObterPedidoPorIdAsync(int id);
        Task<IEnumerable<PedidoDistribuidorResponseDto>> ListarPedidosAsync();
        Task<IEnumerable<PedidoDistribuidorResponseDto>> ObterConcluidosAsync();
        Task<IEnumerable<PedidoDistribuidorResponseDto>> ObterPendentesAsync();
        Task<PedidoDistribuidorResponseDto> AtualizarStatusAsync(int id, bool sucesso, string? retorno = null);
    }
}
