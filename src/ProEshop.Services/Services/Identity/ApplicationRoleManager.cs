using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEshop.DataLayer.Context;
using ProEshop.Entities.Identity;
using ProEshop.Services.Contracts.Identity;

namespace ProEshop.Services.Services.Identity;

public class ApplicationRoleManager
    : RoleManager<Role>,
    IApplicationRoleManager
{
    public ApplicationRoleManager(
        IApplicationRoleStore store,
        IEnumerable<IRoleValidator<Role>> roleValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        ILogger<ApplicationRoleManager> logger
        ) :
        base((RoleStore<Role, ApplicationDbContext, long, UserRole, RoleClaim>)store,
            roleValidators, keyNormalizer, errors, logger)
    {
    }
}
