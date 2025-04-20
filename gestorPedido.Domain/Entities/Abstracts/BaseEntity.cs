using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gestorPedido.Domain.Entities.Abstracts
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted => DeletedAt.HasValue;
    }
}
