using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Enums;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Infra.Repositories
{
    public class PedidoDistribuidorRepository : IPedidoDistribuidorRepository
    {
        private readonly GestorPedidosDbContext _context;

        public PedidoDistribuidorRepository(GestorPedidosDbContext context)
        {
            _context = context;
        }

        public async Task<PedidoDistribuidor?> ObterPedidoDistribuidorPorIdAsync(int id)
        {
            return await _context.PedidoDistribuidores
                .Include(p => p.Revenda)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PedidoDistribuidor>> ListarPedidosAsync()
        {
            return await _context.PedidoDistribuidores
                .Include(p => p.Revenda)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .ToListAsync();
        }

        public async Task AdicionarPedidoAsync(PedidoDistribuidor pedidoDistribuidor)
        {
            await _context.PedidoDistribuidores.AddAsync(pedidoDistribuidor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PedidoDistribuidor>> ObterConcluidosAsync()
        {
            return await _context.PedidoDistribuidores
                .Include(p => p.Revenda)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Where(p => p.Status == StatusPedidoDistribuidor.Concluido)
                .ToListAsync();
        }

        public async Task<IEnumerable<PedidoDistribuidor>> ObterPendentesAsync()
        {
            return await _context.PedidoDistribuidores
                .Include(p => p.Revenda)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Where(p => p.Status == StatusPedidoDistribuidor.Pendente)
                .ToListAsync();
        }

        public async Task AtualizarPedidoDistribuidorAsync(PedidoDistribuidor pedidoDistribuidor)
        {
            _context.PedidoDistribuidores.Update(pedidoDistribuidor);
            await _context.SaveChangesAsync();
        }
    }
}
