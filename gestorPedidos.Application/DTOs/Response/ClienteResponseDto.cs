using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidos.Application.DTOs.Response
{
    public class ClienteResponseDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RevendaId { get; set; }
        public List<ContatoDto> Contatos { get; set; } = new();
        public List<EnderecoDto> Enderecos { get; set; } = new();
    }
}
