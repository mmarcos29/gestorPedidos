using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidos.Application.Mappers
{
    public static class PedidoMapper
    {
        public static PedidoResponseDto MapearPedidoResponse(Pedido pedido)
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

        public static Pedido MapearPedido(PedidoDto pedidoDto, Revenda revenda)
        {
            return new Pedido
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
        }
    }
}
