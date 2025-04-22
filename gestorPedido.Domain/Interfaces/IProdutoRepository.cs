using gestorPedido.Domain.Entities;

namespace gestorPedido.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto?> GetByIdAsync(int id);
        Task<List<Produto>> ObterProdutosPorIdsAsync(IEnumerable<int> ids);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Produto produto);
    }
}
