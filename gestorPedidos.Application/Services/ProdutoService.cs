using gestorPedido.Domain.Interfaces;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Exceptions;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Mappers;

namespace gestorPedidos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoResponseDto>> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return produtos.Select(ProdutoMapper.ToResponseDto);
        }

        public async Task<ProdutoResponseDto?> GetByIdAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
                throw new NotFoundException("Produto não encontrado.");

            return ProdutoMapper.ToResponseDto(produto);
        }

        public async Task<ProdutoResponseDto> CreateAsync(ProdutoDto dto)
        {
            var produto = ProdutoMapper.ToEntity(dto);            
            await _produtoRepository.AddAsync(produto);
            return ProdutoMapper.ToResponseDto(produto);
        }

        public async Task UpdateAsync(int id, ProdutoDto dto)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
                throw new NotFoundException("Produto não encontrado.");

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.Preco = dto.Preco;
            produto.Estoque = dto.Estoque;

            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
                throw new NotFoundException("Produto não encontrado.");

            await _produtoRepository.DeleteAsync(produto);
        }

        public async Task<ProdutoResponseDto> AdicionarEstoqueAsync(AdicionarEstoqueDto dto)
        {
            if (dto.Quantidade <= 0)
                throw new BadRequestException("A quantidade deve ser maior que zero.");

            var produto = await _produtoRepository.GetByIdAsync(dto.Idproduto);

            if (produto == null)
                throw new NotFoundException("Produto não encontrado.");

            produto.Estoque += dto.Quantidade;

            await _produtoRepository.UpdateAsync(produto);

            return ProdutoMapper.ToResponseDto(produto);
        }
    }
}