using Microsoft.EntityFrameworkCore;
using ProEShop.Entities.AuditableEntity;
using ProEShop.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEShop.Entities;

[Table("Sellers")]
[Index(nameof(Seller.ShabaNumber), IsUnique = true)]
[Index(nameof(Seller.ShopName), IsUnique = true)]
public class Seller : EntityBase, IAuditableEntity
{
    #region Properties
    public long UserId { get; set; }

    public bool IsRealPerson { get; set; }

    #region Legal person

    [MaxLength(200)]
    public string CompanyName { get; set; }

    [MaxLength(100)]
    public string RegisterNumber { get; set; }

    [MaxLength(12)]
    public string EconomicCode { get; set; }

    [MaxLength(300)]
    public string SignatureOwners { get; set; }

    [MaxLength(30)]
    public string NationalId { get; set; }

    public CompanyType CompanyType { get; set; }

    public Gender Gender { get; set; }

    public int SellerCode { get; set; }

    public string ShopName { get; set; }

    [Column(TypeName ="ntext")]
    public string AboutSeller { get; set; }

    [MaxLength(50)]
    public string Logo { get; set; }

    [MaxLength(50)]
    public string IdCartPicture { get; set; }

    [MaxLength(24)]
    public string ShabaNumber { get; set; }

    public string Phone { get; set; }

    public string Website { get; set; }

    public ProvinceAndCity Province { get; set; }

    public ProvinceAndCity City { get; set; }

    [MaxLength(300)]
    public string Address { get; set; }

    [MaxLength(11)]
    public string PostalCode { get; set; }

    [MaxLength(100)]
    public string Location { get; set; }

    public bool IsDocumentApproved { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDateTime { get; set; }

    #endregion

    #endregion



    #region Relations
    public User User { get; set; }
    #endregion
}

public enum Gender
{
    [Display(Name = "مرد")]
    Male,
    [Display(Name = "زن")]
    Female,
    [Display(Name = "سایر")]
    Other,

}
public enum CompanyType
{
    [Display(Name = "سهامی عام")]
    PublicShares,
    [Display(Name = "سهامی خاص")]
    PrivateShares,
    [Display(Name = "مسئوایت محدود")]
    LimitedLiability,
    [Display(Name = "تعاونی")]
    Cooperative,
    [Display(Name = "تضامنی")]
    Jointؤenture
}