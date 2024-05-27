using AutoMapper;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.WebEncoders;
using ProEShop.IocConfig;
using ProEShop.ViewModels.Identity.Settings;
using ProEShop.Web.Mappings;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<SiteSettings>(options => builder.Configuration.Bind(options));
builder.Services.Configure<ContentSecurityPolicyConfig>(options => builder.Configuration.GetSection("ContentSecurityPolicyConfig").Bind(options));
// Adds all of the ASP.NET Core Identity related services and configurations at once.
builder.Services.AddCustomIdentityServices();
builder.Services.AddRazorPages();
    //.AddRazorRuntimeCompilation();
builder.Services.Configure<WebEncoderOptions>(options =>
{
    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
});

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();
app.Services.InitializeDb();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseStaticFiles(new StaticFileOptions
//{
//    ContentTypeProvider = new FileExtensionContentTypeProvider(new Dictionary<string, string>
//    {
//        { ".css", "text/css" }
//    })
//});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseContentSecurityPolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
