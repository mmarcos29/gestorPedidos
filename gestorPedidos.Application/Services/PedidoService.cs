using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Exceptions;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Mappers;
using Microsoft.IdentityModel.Tokens;

namespace gestorPedidos.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IRevendaRepository _revendaRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, IRevendaRepository revendaRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _revendaRepository = revendaRepository;
        }

        public async Task<PedidoResponseDto> CriarPedidoAsync(PedidoDto pedidoDto)
        {
            var revenda = await _revendaRepository.ObterPorIdAsync(pedidoDto.RevendaId);
            if (revenda == null)            
                throw new NotFoundException($"Revenda com ID {pedidoDto.RevendaId} não encontrada.");

            var produtosIds = pedidoDto.Itens?
                .Select(i => i.ProdutoId)
                .ToList() ?? new List<int>();
            var produtosExistentes = await _produtoRepository.ObterProdutosPorIdsAsync(produtosIds);

            if (produtosIds.IsNullOrEmpty() || (produtosIds.Count != produtosExistentes.Count()))
                throw new NotFoundException("Um ou mais produtos não encontrados");

            var pedido = PedidoMapper.MapearPedido(pedidoDto, revenda);
            await _pedidoRepository.AdicionarPedidoAsync(pedido);

            return PedidoMapper.MapearPedidoResponse(pedido);
        }

        public async Task<PedidoResponseDto?> ObterPedidoPorIdAsync(int id)
        {
            var pedido = await _pedidoRepository.ObterPedidoPorIdAsync(id);

            if (pedido == null)
                throw new NotFoundException("Pedido não encontrado");

            return PedidoMapper.MapearPedidoResponse(pedido);
        }

        public async Task<IEnumerable<PedidoResponseDto>> ListarPedidosAsync()
        {
            var pedidos = await _pedidoRepository.ListarPedidosAsync();
            return pedidos.Select(PedidoMapper.MapearPedidoResponse);
        }

        public async Task<PedidoResponseDto> AtualizarPedidoAsync(int id, PedidoDto pedidoDto)
        {
            var pedido = await _pedidoRepository.ObterPedidoPorIdAsync(id);

            if (pedido == null)
                throw new NotFoundException("Pedido não encontrado");

            pedido.ClienteId = pedidoDto.ClienteId;
            pedido.RevendaId = pedidoDto.RevendaId;

            pedido.Itens ??= new List<ItemPedido>();
            pedido.Itens.Clear();
            pedido.Itens.AddRange((pedidoDto.Itens ?? Enumerable.Empty<ItemPedidoDto>()).Select(i => new ItemPedido
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade
            }));

            await _pedidoRepository.AtualizarPedidoAsync(pedido);
            return PedidoMapper.MapearPedidoResponse(pedido);
        }

        public async Task ExcluirPedidoAsync(int id)
        {
            var pedido = await _pedidoRepository.ObterPedidoPorIdAsync(id);

            if (pedido == null)
                throw new NotFoundException("Pedido não encontrado");
            pedido.DeletedAt = DateTime.Now;
            await _pedidoRepository.AtualizarPedidoAsync(pedido);
        }
    }
}
