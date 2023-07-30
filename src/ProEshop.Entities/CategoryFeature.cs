using ProEShop.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEShop.Entities;

[Table("CategoryFeatures")]
public class CategoryFeature : EntityBase, IAuditableEntity
{
    #region Properties
    public long CategoryId { get; set; }
    public long FeatureId { get; set; }
    #endregion

    #region Relations
    public Category Category { get; set; }
    public Feature Feature { get; set; }
    #endregion
}
