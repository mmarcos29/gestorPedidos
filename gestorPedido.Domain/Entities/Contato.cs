using gestorPedido.Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gestorPedido.Domain.Entities
{
    public class Contato : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string Nome { get; set; }

        public bool Principal { get; set; }

        [JsonIgnore]
        [ForeignKey("Revenda")]
        public int? RevendaId { get; set; }

        [JsonIgnore]
        public Revenda? Revenda { get; set; }

        [JsonIgnore]
        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }

        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        public List<Telefone> Telefones { get; set; } = new();
    }
}