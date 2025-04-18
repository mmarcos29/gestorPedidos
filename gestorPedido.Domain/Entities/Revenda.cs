using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedido.Domain.Entities
{
    public class Revenda
    {
        public int Id { get; set; }

        [Required]
        
        public string Cnpj { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        public string NomeFantasia { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<Telefone> Telefones { get; set; } = new();
        public List<Contato> Contatos { get; set; } = new();
        public List<Endereco> Enderecos { get; set; } = new();
    }
}

