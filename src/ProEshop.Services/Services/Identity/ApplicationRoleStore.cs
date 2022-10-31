using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProEshop.DataLayer.Context;
using ProEshop.Entities.Identity;
using ProEshop.Services.Contracts.Identity;


namespace ProEshop.Services.Services.Identity;
/// <summary>
///را پیاده سازی کند CRUD بتواند روی موجودیت نقش های عملیات ApplicationRoleManager  بستری را فراهم میکند که ApplicationDbContext با دسترسی پیدا کردن به  ApplicationRoleStore
///را هم عوض کرد ORM همچنین لایه دسترسی به دیتا را کپسوله میکند که با این ویژگی حتی میتوان 
/// </summary>
public class ApplicationRoleStore
    : RoleStore<Role, ApplicationDbContext, long, UserRole, RoleClaim>,
    IApplicationRoleStore
{
    public ApplicationRoleStore(
        IUnitOfWork unitOfWork,
        IdentityErrorDescriber describer = null) :
        base((ApplicationDbContext)unitOfWork, describer)
    {
    }
}
