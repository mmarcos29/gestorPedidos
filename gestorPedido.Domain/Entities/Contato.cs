using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedido.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public bool Principal { get; set; }

        public int RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }
}
