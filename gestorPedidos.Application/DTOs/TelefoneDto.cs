using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidos.Application.DTOs
{
    public class TelefoneDto
    {
        public required string Ddd { get; set; }
        public required string Numero { get; set; }
    }
}
