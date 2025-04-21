using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Exceptions;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Mappers;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly GestorPedidosDbContext _context;

        public ProdutoService(GestorPedidosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoResponseDto>> GetAllAsync()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return produtos.Select(ProdutoMapper.ToResponseDto);
        }

        public async Task<ProdutoResponseDto?> GetByIdAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                throw new NotFoundException("Produto não encontrado.");

            return ProdutoMapper.ToResponseDto(produto);
        }

        public async Task<ProdutoResponseDto> CreateAsync(ProdutoDto dto)
        {
            var produto = ProdutoMapper.ToEntity(dto);
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return ProdutoMapper.ToResponseDto(produto);
        }

        public async Task UpdateAsync(int id, ProdutoDto dto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                throw new NotFoundException("Produto não encontrado.");

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.Preco = dto.Preco;
            produto.Estoque = dto.Estoque;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                throw new NotFoundException("Produto não encontrado.");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<ProdutoResponseDto> AdicionarEstoqueAsync(AdicionarEstoqueDto dto)
        {
            if (dto.Quantidade <= 0)
                throw new BadRequestException("A quantidade deve ser maior que zero.");

            var produto = await _context.Produtos.FindAsync(dto.Idproduto);

            if (produto == null)
                throw new NotFoundException("Produto não encontrado.");

            produto.Estoque += dto.Quantidade;

            await _context.SaveChangesAsync();

            return ProdutoMapper.ToResponseDto(produto);
        }
    }
}