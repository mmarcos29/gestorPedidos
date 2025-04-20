using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Exceptions;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace gestorPedidos.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly GestorPedidosDbContext _context;
        private readonly ILogger<PedidoService> _logger;

        public PedidoService(GestorPedidosDbContext context, ILogger<PedidoService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PedidoResponseDto> CriarPedidoAsync(PedidoDto pedidoDto)
        {
            var revenda = await _context.Revendas
                .Include(r => r.Contatos)
                .Include(r => r.Enderecos)
                .FirstOrDefaultAsync(r => r.Id == pedidoDto.RevendaId);

            if (revenda == null)
            {
                _logger.LogError("Revenda não encontrada para o ID: {RevendaId}", pedidoDto.RevendaId);
                throw new NotFoundException($"Revenda com ID {pedidoDto.RevendaId} não encontrada.");
            }

            var produtosIds = pedidoDto.Itens?
                .Select(i => i.ProdutoId)
                .ToList() ?? new List<int>();
            var produtosExistentes = await _context.Produtos
                .Where(p => produtosIds.Contains(p.Id))
                .Select(p => p.Id)
                .ToListAsync();

            if (produtosIds.IsNullOrEmpty() || (produtosIds.Count != produtosExistentes.Count))
            {
                _logger.LogError("Um ou mais produtos não encontrados");
                throw new NotFoundException("Um ou mais produtos não encontrados");
            }

            var pedido = new Pedido
            {
                Revenda = revenda,
                ClienteId = pedidoDto.ClienteId,
                DataPedido = DateTime.Now,
                Itens = (pedidoDto.Itens ?? new List<ItemPedidoDto>()).Select(i => new ItemPedido
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            var pedidoResponse = new PedidoResponseDto
            {
                PedidoId = pedido.Id,
                Itens = pedido.Itens.Select(i => new ItemPedidoResponseDto
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            return pedidoResponse;
        }

        public async Task<PedidoResponseDto?> ObterPedidoPorIdAsync(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Revenda)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
                throw new NotFoundException("Pedido não encontrado");

            return MapearPedidoResponse(pedido);
        }

        public async Task<IEnumerable<PedidoResponseDto>> ListarPedidosAsync()
        {
            var pedidos = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Revenda)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .ToListAsync();

            return pedidos.Select(MapearPedidoResponse);
        }

        public async Task<PedidoResponseDto> AtualizarPedidoAsync(int id, PedidoDto pedidoDto)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Revenda)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
                throw new NotFoundException("Pedido não encontrado");

            pedido.ClienteId = pedidoDto.ClienteId;
            pedido.RevendaId = pedidoDto.RevendaId;

            // Garante que a lista está inicializada
            pedido.Itens ??= new List<ItemPedido>();

            pedido.Itens.Clear();
            pedido.Itens.AddRange((pedidoDto.Itens ?? Enumerable.Empty<ItemPedidoDto>()).Select(i => new ItemPedido
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade
            }));

            await _context.SaveChangesAsync();

            return MapearPedidoResponse(pedido);
        }

        public async Task ExcluirPedidoAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
                throw new NotFoundException("Pedido não encontrado");

            pedido.DeletedAt = DateTime.Now;
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        private static PedidoResponseDto MapearPedidoResponse(Pedido pedido)
        {
            var itens = pedido.Itens?.Select(i => new ItemPedidoResponseDto
            {
                ProdutoId = i.ProdutoId,
                ProdutoNome = i.Produto?.Nome ?? string.Empty,
                Quantidade = i.Quantidade,
                PrecoUnitario = i.Produto?.Preco ?? 0,
                Subtotal = i.Quantidade * (i.Produto?.Preco ?? 0)
            }).ToList() ?? new List<ItemPedidoResponseDto>();

            return new PedidoResponseDto
            {
                PedidoId = pedido.Id,
                ClienteId = pedido.ClienteId,
                ClienteNome = pedido.Cliente?.Nome ?? string.Empty,
                RevendaId = pedido.RevendaId,
                RevendaNome = pedido.Revenda?.NomeFantasia ?? string.Empty,
                DataPedido = pedido.DataPedido,
                Itens = itens,
                TotalPedido = itens.Sum(i => i.Subtotal)
            };
        }
    }
}
