using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly GestorPedidosDbContext _context;

        public ProdutoRepository(GestorPedidosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync() => await _context.Produtos.ToListAsync();

        public async Task<Produto?> GetByIdAsync(int id) => await _context.Produtos.FindAsync(id);

        public async Task<List<Produto>> ObterProdutosPorIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Produtos
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produto produto)
        {
            produto.DeletedAt = DateTime.UtcNow;
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
