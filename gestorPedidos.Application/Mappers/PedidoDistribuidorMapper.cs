using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Enums;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;

namespace gestorPedidos.Application.Mappers
{
    public static class PedidoDistribuidorMapper
    {
        public static PedidoDistribuidor MapearPedido(PedidoDistribuidorDto dto, Revenda revenda)
        {
            return new PedidoDistribuidor
            {
                RevendaId = dto.RevendaId,
                Revenda = revenda,
                DataPedido = DateTime.Now,
                Status = StatusPedidoDistribuidor.Pendente,
                Itens = dto.Itens.Select(i => new ItemPedido
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            };
        }

        public static PedidoDistribuidorResponseDto MapearPedidoResponse(PedidoDistribuidor pedidoDistribuidor)
        {
            return new PedidoDistribuidorResponseDto
            {
                Id = pedidoDistribuidor.Id,
                RevendaId = pedidoDistribuidor.RevendaId,
                NomeRevenda = pedidoDistribuidor.Revenda?.NomeFantasia ?? string.Empty,
                Status = pedidoDistribuidor.Status.ToString(),
                DataCriacao = pedidoDistribuidor.DataPedido,
                Retorno = pedidoDistribuidor.Retorno,
                Itens = pedidoDistribuidor.Itens.Select(i => new ItemPedidoDistribuidorResponseDto
                {
                    ProdutoId = i.ProdutoId,
                    NomeProduto = i.Produto?.Nome,
                    Quantidade = i.Quantidade
                }).ToList()
            };
        }
    }
}
