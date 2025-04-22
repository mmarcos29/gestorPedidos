using gestorPedido.Domain.Enums;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Exceptions;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Mappers;
using gestorPedidos.Application.Messaging.Interfaces;

namespace gestorPedidos.Application.Services
{
    public class PedidoDistribuidorService : IPedidoDistribuidorService
    {
        private readonly IPedidoDistribuidorRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IRevendaRepository _revendaRepository;
        private readonly IPedidoDistribuidorQueue _queue;

        public PedidoDistribuidorService(
            IPedidoDistribuidorRepository repository, 
            IProdutoRepository produtoRepository, 
            IRevendaRepository revendaRepository, 
            IPedidoDistribuidorQueue queue)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
            _revendaRepository = revendaRepository;
            _queue = queue;
        }

        public async Task<PedidoDistribuidorResponseDto> CriarPedidoAsync(PedidoDistribuidorDto dto)
        {
            var totalProdutos = dto.Itens?.Sum(i => i.Quantidade) ?? 0;
            if (totalProdutos < 1000)
                throw new ValidationException("O pedido deve conter no mínimo 1000 produtos no total.");

            var revenda = await _revendaRepository.ObterPorIdAsync(dto.RevendaId)
                ?? throw new NotFoundException($"Revenda com ID {dto.RevendaId} não encontrada.");

            var produtosIds = dto.Itens?.Select(i => i.ProdutoId).ToList() ?? new();
            var produtos = await _produtoRepository.ObterProdutosPorIdsAsync(produtosIds);
            if (produtos.Count() != produtosIds.Count)
                throw new NotFoundException("Um ou mais produtos não encontrados.");

            var pedido = PedidoDistribuidorMapper.MapearPedido(dto, revenda);
            await _repository.AdicionarPedidoAsync(pedido);
            await _queue.EnfileirarAsync(pedido);
            return PedidoDistribuidorMapper.MapearPedidoResponse(pedido);
        }

        public async Task<PedidoDistribuidorResponseDto?> ObterPedidoPorIdAsync(int id)
        {
            var pedidoDistribuidor = await _repository.ObterPedidoDistribuidorPorIdAsync(id)
                ?? throw new NotFoundException("Pedido não encontrado");

            return PedidoDistribuidorMapper.MapearPedidoResponse(pedidoDistribuidor);
        }

        public async Task<IEnumerable<PedidoDistribuidorResponseDto>> ListarPedidosAsync()
        {
            var pedidosDistribuidor = await _repository.ListarPedidosAsync();
            return pedidosDistribuidor.Select(PedidoDistribuidorMapper.MapearPedidoResponse);
        }

        public async Task<IEnumerable<PedidoDistribuidorResponseDto>> ObterConcluidosAsync()
        {
            var pedidosDistribuidor = await _repository.ObterConcluidosAsync();
            return pedidosDistribuidor.Select(PedidoDistribuidorMapper.MapearPedidoResponse);
        }

        public async Task<IEnumerable<PedidoDistribuidorResponseDto>> ObterPendentesAsync()
        {
            var pedidosDistribuidor = await _repository.ObterPendentesAsync();
            return pedidosDistribuidor.Select(PedidoDistribuidorMapper.MapearPedidoResponse);
        }

        public async Task<PedidoDistribuidorResponseDto> AtualizarStatusAsync(int id, bool sucesso, string? retorno = null)
        {
            var pedidoDistribuidor = await _repository.ObterPedidoDistribuidorPorIdAsync(id)
                ?? throw new NotFoundException("Pedido não encontrado");

            pedidoDistribuidor.Status = StatusPedidoDistribuidor.Concluido;
            pedidoDistribuidor.Sucesso = sucesso;
            pedidoDistribuidor.Retorno = retorno;

            await _repository.AtualizarPedidoDistribuidorAsync(pedidoDistribuidor);
            return PedidoDistribuidorMapper.MapearPedidoResponse(pedidoDistribuidor);
        }
    }
}
