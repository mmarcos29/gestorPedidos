using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedido.Domain.Entities
{
    public class Telefone
    {
        public int Id { get; set; }

        [Phone]
        public string Numero { get; set; }

        public int RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }
}
