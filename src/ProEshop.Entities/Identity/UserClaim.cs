using Microsoft.AspNetCore.Identity;
using ProEshop.Entities.AuditableEntity;

namespace ProEshop.Entities.Identity;

/// <summary>
///متعلق به یک کاربر است Claim داشته باشد و هر Claim هر کاربر میتواند چندین 
/// </summary>
public class UserClaim : IdentityUserClaim<long>, IAuditableEntity
{
    public virtual User User { get; set; }
}
