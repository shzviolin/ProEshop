using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProEshop.DataLayer.Context;
using ProEshop.Entities.Identity;
using ProEshop.Services.Contracts;
using ProEshop.Services.Contracts.Identity;
using ProEshop.Services.Services;
using ProEshop.Services.Services.Identity;
using System.Security.Claims;
using System.Security.Principal;

namespace ProEshop.IocConfig;

public static class AddCustomServicesExtensions
{
    //شده خودمون را بهش میدیم Customize درخواستی داد ما نمونه  Identity Asp.net core خط های دوم برای این است که اگر سیستم توکار خود 
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IPrincipal>(provider =>
            provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.User ?? ClaimsPrincipal.Current);

        services.AddScoped<IUserClaimsPrincipalFactory<User>, ApplicationClaimsPrincipalFactory>();
        services.AddScoped<UserClaimsPrincipalFactory<User, Role>, ApplicationClaimsPrincipalFactory>();

        services.AddScoped<IdentityErrorDescriber, CustomIdentityErrorDescriber>();

        services.AddScoped<IApplicationUserStore, ApplicationUserStore>();
        services.AddScoped<UserStore<User, Role, ApplicationDbContext, long, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>, ApplicationUserStore>();

        services.AddScoped<IApplicationRoleStore, ApplicationRoleStore>();
        services.AddScoped<RoleStore<Role, ApplicationDbContext, long, UserRole, RoleClaim>, ApplicationRoleStore>();

        services.AddScoped<IApplicationUserManager, ApplicationUserManager>();
        services.AddScoped<UserManager<User>, ApplicationUserManager>();

        services.AddScoped<IApplicationRoleManager, ApplicationRoleManager>();
        services.AddScoped<RoleManager<Role>, ApplicationRoleManager>();

        services.AddScoped<IApplicationSignInManager, ApplicationSignInManager>();
        services.AddScoped<SignInManager<User>, ApplicationSignInManager>();

        services.AddScoped<IIdentityDbInitializer, IdentityDbInitializer>();

        services.AddScoped<ISmsSender, AuthMessageSender>();
        services.AddScoped<IHttpClientService, HttpClientService>();

        return services;
    }
}
