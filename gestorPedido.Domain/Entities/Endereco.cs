using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedido.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required]
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "CEP inválido")]
        public string Cep { get; set; }

        public int RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }
}
