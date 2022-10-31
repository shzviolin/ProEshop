using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProEshop.DataLayer.Context;
using ProEshop.Entities.Identity;
using ProEshop.Services.Contracts.Identity;


namespace ProEshop.Services.Services.Identity;

public class ApplicationUserManager
    : UserManager<User>, IApplicationUserManager
{
    private readonly DbSet<User> _users;

    public ApplicationUserManager(
        IApplicationUserStore store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher,
        IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<ApplicationUserManager> logger,
        IUnitOfWork unitOfWork
        )
        : base((UserStore<User, Role, ApplicationDbContext, long, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>)store,
            optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _users=unitOfWork.Set<User>();
    }

    #region CustomClass

    public async Task<DateTime?>GetSendSmsLastTimeAsync(string phoneNumber)
    {
        var result=await _users.Select(x=>new
        {
            x.UserName,
            x.SendSmsLastTime
        }).SingleOrDefaultAsync(x=>x.UserName==phoneNumber);
        return result?.SendSmsLastTime;
    }

    #endregion
}
