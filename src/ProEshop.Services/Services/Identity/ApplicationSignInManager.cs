using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProEshop.Entities.Identity;
using ProEshop.Services.Contracts.Identity;


namespace ProEshop.Services.Services.Identity;
/// <summary>
/// بستری را در اختیار ما قرار میدهد که عملیات لاگین کاربران را با آن انجام دهیم
/// </summary>
public class ApplicationSignInManager
    : SignInManager<User>, IApplicationSignInManager
{
    public ApplicationSignInManager(
        IApplicationUserManager userManager,
        IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<User> claimsFactory,
        IOptions<IdentityOptions> optionsAccessor,
        ILogger<ApplicationSignInManager> logger,
        IAuthenticationSchemeProvider schemes,
        IUserConfirmation<User> confirmation)
        : base((UserManager<User>)userManager,
            contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
    {
    }
}
