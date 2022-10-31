using Microsoft.AspNetCore.Identity;
using ProEshop.Entities.AuditableEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProEshop.Entities.Identity;

public class User : IdentityUser<long>, IAuditableEntity
{
    [MaxLength(200)]
    public string FirstName { get; set; }

    [MaxLength(200)]
    public string LastName { get; set; }

    /// <summary>
    /// This property is not added to the database
    /// </summary>
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    public bool IsActive { get; set; } = true;

    public DateTime CreatDateTime { get; set; }

    [Required]
    [MaxLength(50)]
    public string Avatar { get; set; }
    public DateTime SendSmsLastTime { get; set; }

    #region associations
    public virtual ICollection<UserClaim> UserClaims { get; set; }
    public virtual ICollection<UserLogin> UserLogins { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<UserToken> UserTokens { get; set; }
    #endregion
}