using gestorPedido.Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gestorPedido.Domain.Entities
{
    public class Telefone : BaseEntity
    {
        [Required]
        public required string Ddd { get; set; }

        [Phone]
        public required string Numero { get; set; }

        [JsonIgnore]
        public int ContatoId { get; set; }

        [JsonIgnore]
        public Contato? Contato { get; set; }
    }
}
