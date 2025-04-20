using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs.Response;

namespace gestorPedido.Domain.Interfaces
{
    public interface IRevendaService
    {
        Task<IEnumerable<RevendaResponseDto>> ListarRevendasAsync();
        Task<RevendaResponseDto> ObterRevendaPorIdAsync(int id);
        Task<RevendaResponseDto> CadastrarRevendaAsync(RevendaDto dto);
        Task AtualizarRevendaAsync(int id, Revenda dto);
        Task ExcluirRevendaAsync(int id);
    }
}

