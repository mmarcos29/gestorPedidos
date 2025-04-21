using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidos.Application.DTOs
{
    public class AdicionarEstoqueDto
    {
        public int Idproduto { get; set; }
        public int Quantidade { get; set; }
    }
}
