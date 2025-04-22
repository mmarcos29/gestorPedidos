using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly GestorPedidosDbContext _context;
        private readonly IContactAdressRepository _ContactAdressRepository;

        public ClienteRepository(GestorPedidosDbContext context, IContactAdressRepository ContactAdressRepository)
        {
            _context = context;
            _ContactAdressRepository = ContactAdressRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Include(c => c.Contatos).ThenInclude(t => t.Telefones)
                .Include(c => c.Enderecos)
                .Include(c => c.Revenda)
                .ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Contatos).ThenInclude(t => t.Telefones)
                .Include(c => c.Enderecos)
                .Include(c => c.Revenda)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente oldClient, Cliente cliente )
        {
            await _ContactAdressRepository.ClearContactAdressAsync(oldClient.Contatos, oldClient.Enderecos);
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            await _ContactAdressRepository.ClearContactAdressAsync(cliente.Contatos, cliente.Enderecos);
            cliente.DeletedAt = DateTime.UtcNow;
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
