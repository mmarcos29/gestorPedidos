using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Infra.Repositories
{
    public class ContactAdressRepository : IContactAdressRepository
    {
        private readonly GestorPedidosDbContext _context;
        
        public ContactAdressRepository(GestorPedidosDbContext context)
        {
            _context = context;
        }

        public async Task ClearContactAdressAsync(ICollection<Contato> contatos, ICollection<Endereco> enderecos)
        {
            _context.Contatos.RemoveRange(contatos);
            _context.Enderecos.RemoveRange(enderecos);
            await _context.SaveChangesAsync();
        }
    }
}
