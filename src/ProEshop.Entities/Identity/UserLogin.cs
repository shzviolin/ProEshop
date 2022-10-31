using Microsoft.AspNetCore.Identity;
using ProEshop.Entities.AuditableEntity;

namespace ProEshop.Entities.Identity;

/// <summary>
/// We use yhis for external login via google,facebook,...
/// </summary>
public class UserLogin : IdentityUserLogin<long>, IAuditableEntity
{
    public virtual User User { get; set; }
}
