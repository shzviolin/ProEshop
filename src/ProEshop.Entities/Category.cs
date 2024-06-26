﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProEShop.Entities.AuditableEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProEShop.Entities;

[Index(nameof(Category.Slug),IsUnique=true)]
[Index(nameof(Category.Title),IsUnique=true)]
[Table("Categories")]
public class Category : EntityBase, IAuditableEntity
{
    #region Properties
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    [MaxLength(130)]
    public string Slug { get; set; }

    [MaxLength(50)]
    public string Picture { get; set; }

    public long? ParentId { get; set; }

    public bool ShowInMenus { get; set; }
    #endregion

    #region Relations

    public Category Parent { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<CategoryFeature> CategoryFeatures { get; set; }

    #endregion
}
