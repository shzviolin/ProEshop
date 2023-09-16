using Microsoft.EntityFrameworkCore;
using ProEShop.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEShop.Entities;

[Table("ProvincesAndCities")]
public class ProvinceAndCity : EntityBase, IAuditableEntity
{
    #region Properties
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    public long? ParentId { get; set; }
    #endregion

    #region Relations
    public ProvinceAndCity Parent { get; set; }
      
    #endregion
}
