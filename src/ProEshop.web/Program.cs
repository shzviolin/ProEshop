using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.WebEncoders;
using ProEshop.IocConfig;
using ProEshop.ViewModels.Identity.Settings;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//بایند میکند SiteSetting داده ایم را میگیرد و با کلاس  appSetting.json مقادیری که در 
builder.Services.Configure<SiteSettings>(options => builder.Configuration.Bind(options));
builder.Services.Configure<ContentSecurityPolicyConfig>(options => builder.Configuration.GetSection("ContentSecurityPolicyConfig").Bind(options));
builder.Services.AddCustomIdentityServices();
builder.Services.AddRazorPages();
    //.AddRazorRuntimeCompilation();

//to show Persian Title of website correctly
builder.Services.Configure<WebEncoderOptions>(options =>
{
    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
});

var app = builder.Build();
app.Services.InitializeDb();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseContentSecurityPolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
