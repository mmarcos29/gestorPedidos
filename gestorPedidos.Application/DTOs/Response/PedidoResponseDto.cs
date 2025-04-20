using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidos.Application.DTOs.Response
{
    public class PedidoResponseDto
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public int RevendaId { get; set; }
        public string RevendaNome { get; set; } = string.Empty;
        public DateTime DataPedido { get; set; }
        public List<ItemPedidoResponseDto> Itens { get; set; } = new();
        public decimal TotalPedido { get; set; }
    }
}
