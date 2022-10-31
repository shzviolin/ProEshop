using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProEshop.DataLayer.Context;
using ProEshop.Entities.Identity;
using ProEshop.Services.Contracts.Identity;

namespace ProEshop.Services.Services.Identity;

public class ApplicationUserStore
    : UserStore<User, Role, ApplicationDbContext, long, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>,
    IApplicationUserStore
{
    public ApplicationUserStore(
        IUnitOfWork unitOfWork,
        IdentityErrorDescriber describer = null)
        : base((ApplicationDbContext)unitOfWork, describer)
    {
    }
}
