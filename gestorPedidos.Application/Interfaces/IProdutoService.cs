using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;

namespace gestorPedidos.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoResponseDto>> GetAllAsync();
        Task<ProdutoResponseDto?> GetByIdAsync(int id);
        Task<ProdutoResponseDto> CreateAsync(ProdutoDto dto);
        Task UpdateAsync(int id, ProdutoDto dto);
        Task DeleteAsync(int id);
        Task<ProdutoResponseDto> AdicionarEstoqueAsync(AdicionarEstoqueDto dto);
    }
}