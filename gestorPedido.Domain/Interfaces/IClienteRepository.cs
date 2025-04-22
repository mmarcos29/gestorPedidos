using gestorPedido.Domain.Entities;

namespace gestorPedido.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente oldClient, Cliente cliente);
        Task DeleteAsync(Cliente cliente);
    }
}
