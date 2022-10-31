using DNTCommon.Web.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProEshop.Common.GuardToolkit;
using ProEshop.Common.PersianToolkit;
using ProEshop.DataLayer.Context;
using ProEshop.Services.Contracts.Identity;
using ProEshop.ViewModels.Identity.Settings;

namespace ProEshop.IocConfig;

public static class DbContextOptionsExtensions
{
    public static IServiceCollection AddConfiguredDbContext(this IServiceCollection services, SiteSettings siteSettings)
    {
        siteSettings.CheckArgumentIsNull(nameof(siteSettings));
        var connectionString = siteSettings.ConnectionStrings.ApplicationDbContextConnection;
        //دسترسی داشته باشیم ApplicationDbContext برای این است که در طول یک درخواست فقط یک نسخه از  AddScoped
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());
        // We use `AddDbContextPool` instead of AddDbContext because it's faster
        services.AddDbContextPool<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.AddInterceptors(new PersianYeKeCommandInterceptor());
        });
        return services;
    }

    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        //using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        //{
        //    var context=serviceScope.ServiceProvider.GetRequiredService<IIdentityDbInitializer>();
        //    context.Initialize();
        //    context.SeedData();
        //}

        serviceProvider.RunScopedService<IIdentityDbInitializer>(identityDbInitializer =>
        {
            identityDbInitializer.Initialize();
            identityDbInitializer.SeedData();
        });
    }
}
