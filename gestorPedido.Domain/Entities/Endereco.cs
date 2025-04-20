using gestorPedido.Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gestorPedido.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        [Required]
        public required string Logradouro { get; set; }

        public string? Numero { get; set; }

        [Required]
        public required string Bairro { get; set; }

        [Required]
        public required string Cidade { get; set; }

        [Required]
        public required string Estado { get; set; }

        [Required]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "CEP inválido")]
        public required string Cep { get; set; }

        [JsonIgnore]
        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }

        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        [JsonIgnore]
        [ForeignKey("Revenda")]
        public int? RevendaId { get; set; }

        [JsonIgnore]
        public Revenda? Revenda { get; set; }
    }
}
