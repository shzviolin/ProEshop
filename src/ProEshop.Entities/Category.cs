using ProEshop.Entities.AuditableEntity;
using System.ComponentModel.DataAnnotations;

namespace ProEshop.Entities;

public class Category : EntityBase, IAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
}
