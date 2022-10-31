using Microsoft.AspNetCore.Identity;
using ProEshop.Entities.AuditableEntity;

namespace ProEshop.Entities.Identity;

/// <summary>
///Role و  User جدول واسط بین 
///هر کاربر میتواند چندین نقش داشته باشد و هر نقش میتواند متعلق به چند کاربر باشد
/// </summary>
public class UserRole : IdentityUserRole<long>, IAuditableEntity
{
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}
