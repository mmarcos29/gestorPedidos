using gestorPedido.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidos.Application.DTOs.Response
{
    public class RevendaResponseDto
    {
        public int Id { get; set; }
        public required string Cnpj { get; set; }
        public required string RazaoSocial { get; set; }
        public required string NomeFantasia { get; set; }
        public required string Email { get; set; }

        public required List<ContatoDto> Contatos { get; set; }
        public required List<EnderecoDto> Enderecos { get; set; }
    }
}
