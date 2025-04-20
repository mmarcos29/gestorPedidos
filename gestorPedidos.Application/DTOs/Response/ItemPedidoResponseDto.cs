using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidos.Application.DTOs.Response
{
    public class ItemPedidoResponseDto
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
