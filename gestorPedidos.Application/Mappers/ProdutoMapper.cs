using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.DTOs;

namespace gestorPedidos.Application.Mappers
{
    public static class ProdutoMapper
    {
        public static Produto ToEntity(ProdutoDto dto) => new()
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Preco = dto.Preco,
            Estoque = dto.Estoque
        };

        public static ProdutoResponseDto ToResponseDto(Produto produto) => new()
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Estoque = produto.Estoque
        };
    }
}
