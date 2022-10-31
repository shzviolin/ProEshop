using Microsoft.AspNetCore.Identity;
using ProEshop.Entities.AuditableEntity;

namespace ProEshop.Entities.Identity;

/// <summary>
/// برای احراز هویت داینامیک
/// ها را به نقش های کاربر اضافه میکنیم claim 
/// مثلا میگیم نقش ادمین به فلان صفحه ها دسترسی دارد
/// </summary>
public class RoleClaim : IdentityRoleClaim<long>, IAuditableEntity
{
    public virtual Role Role { get; set; }
}