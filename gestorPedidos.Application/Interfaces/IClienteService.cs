using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;

namespace gestorPedidos.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDto>> GetAllAsync();
        Task<ClienteResponseDto?> GetByIdAsync(int id);
        Task<ClienteResponseDto> CreateAsync(ClienteDto dto);
        Task UpdateAsync(int id, ClienteDto dto);
        Task DeleteAsync(int id);
    }
}
