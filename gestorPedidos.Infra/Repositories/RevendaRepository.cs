using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Infra.Repositories
{
    public class RevendaRepository : IRevendaRepository
    {
        private readonly GestorPedidosDbContext _context;
        private readonly IContactAdressRepository _ContactAdressRepository;

        public RevendaRepository(GestorPedidosDbContext context, IContactAdressRepository contactAdressRepository)
        {
            _context = context;
            _ContactAdressRepository = contactAdressRepository;
        }

        public async Task<IEnumerable<Revenda>> ListarRevendasAsync()
        {
            return await _context.Revendas
                .Include(r => r.Contatos).ThenInclude(c => c.Telefones)
                .Include(r => r.Enderecos)
                .ToListAsync();
        }

        public async Task<Revenda?> ObterPorIdAsync(int id)
        {
            return await _context.Revendas
                .Include(r => r.Contatos).ThenInclude(c => c.Telefones)
                .Include(r => r.Enderecos)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> CnpjExisteAsync(string cnpj)
        {
            return await _context.Revendas.AnyAsync(r => r.Cnpj == cnpj);
        }

        public async Task AdicionarAsync(Revenda revenda)
        {
            await _context.Revendas.AddAsync(revenda);
        }

        public async Task AtualizarAsync(Revenda oldRevenda, Revenda revenda)
        {
            await _ContactAdressRepository.ClearContactAdressAsync(oldRevenda.Contatos, oldRevenda.Enderecos);
            _context.Revendas.Update(revenda);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
