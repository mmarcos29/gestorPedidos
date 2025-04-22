using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly GestorPedidosDbContext _context;

        public PedidoRepository(GestorPedidosDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido?> ObterPedidoPorIdAsync(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Revenda)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pedido>> ListarPedidosAsync()
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Revenda)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .ToListAsync();
        }

        public async Task AdicionarPedidoAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarPedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
