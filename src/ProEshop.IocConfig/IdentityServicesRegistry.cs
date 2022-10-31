using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProEshop.Common.GuardToolkit;
using ProEshop.ViewModels.Identity.Settings;

namespace ProEshop.IocConfig;
public static class IdentityServicesRegistry
{
    /// <summary>
    /// Adds all of the Asp.NET Core Identity related services and configurations at once.
    /// </summary>
    /// <param name="services"></param>
    public static void AddCustomIdentityServices(this IServiceCollection services)
    {
        var siteSettings = GetSiteSettings(services);
        services.AddIdentityOptions(siteSettings);
        services.AddConfiguredDbContext(siteSettings);
        services.AddCustomServices();
    }

    public static SiteSettings GetSiteSettings(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var siteSettingsOptions = provider.GetRequiredService<IOptionsSnapshot<SiteSettings>>();
        var siteSettings = siteSettingsOptions.Value;
        //if(siteSettings == null)
        //    throw new ArgumentNullException(nameof(siteSettings));
        siteSettings.CheckArgumentIsNull(nameof(siteSettings));
        return siteSettings;
    }
}
