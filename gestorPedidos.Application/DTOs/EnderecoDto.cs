using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidos.Application.DTOs
{
    public class EnderecoDto
    {
        public required string Logradouro { get; set; }
        public required string Numero { get; set; }
        public required string Bairro { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
        public required string Cep { get; set; }
    }
}
