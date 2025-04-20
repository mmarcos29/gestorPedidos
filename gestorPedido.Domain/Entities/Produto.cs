using gestorPedido.Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestorPedido.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public required string Nome { get; set; }
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
