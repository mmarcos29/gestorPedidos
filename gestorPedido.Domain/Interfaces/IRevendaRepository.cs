using gestorPedido.Domain.Entities;
namespace gestorPedido.Domain.Interfaces
{
    public interface IRevendaRepository
    {
        Task<IEnumerable<Revenda>> ListarRevendasAsync();
        Task<Revenda?> ObterPorIdAsync(int id);
        Task<bool> CnpjExisteAsync(string cnpj);
        Task AdicionarAsync(Revenda revenda);
        Task AtualizarAsync(Revenda oldRevenda, Revenda revenda);
        Task SaveChangesAsync();
    }
}

