﻿using Microsoft.AspNetCore.Identity;
using ProEShop.Entities.AuditableEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProEShop.Entities.Identity;

public class User : IdentityUser<long>, IAuditableEntity
{
    #region Properties
    [Display(Name = "نام")]
    [MaxLength(200)]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [MaxLength(200)]
    public string LastName { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDateTime { get; set; }

    [Display(Name = "کد ملی")]
    [MaxLength(10)]
    public string NationalCode { get; set; }

    [Display(Name = "تاریخ تولد")]
    public DateTime? BirthDate { get; set; }

    [Display(Name = "جنسیت")]
    public Gender Gender { get; set; }

    [Required]
    [MaxLength(50)]
    public string Avatar { get; set; }

    public DateTime SendSmsLastTime { get; set; }

    public bool IsSeller { get; set; }
    #endregion


    #region Relations
    public virtual ICollection<UserClaim> UserClaims { get; set; }
    public virtual ICollection<UserLogin> UserLogins { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<UserToken> UserTokens { get; set; }
    public Seller Seller { get; set; }
    #endregion
}


public enum Gender : byte
{
    [Display(Name = "مرد")]
    Male,
    [Display(Name = "زن")]
    Female,
    [Display(Name = "سایر")]
    Other,
}