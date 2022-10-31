using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ProEshop.Common.Constants;
using ProEshop.Common.Helpers;
using ProEshop.Common.IdentityToolkit;
using ProEshop.Entities.Identity;
using ProEshop.Services.Contracts.Identity;
using ProEshop.ViewModels.Identity;
using ProEshop.ViewModels.Identity.Settings;


namespace ProEshop.web.Pages.Identity;

public class RegisterLoginModel : PageModel
{
    #region Constructor

    private readonly IApplicationUserManager _userManager;
    private readonly ILogger<RegisterLoginModel> _logger;
    private readonly ISmsSender _smsSender;
    private readonly SiteSettings _siteSettings;
    public RegisterLoginModel(
        IApplicationUserManager userManager,
        ILogger<RegisterLoginModel> logger,
        IOptionsMonitor<SiteSettings> siteSettings,
        ISmsSender smsSender
        )
    {
        _userManager = userManager;
        _logger = logger;
        _smsSender = smsSender;
        _siteSettings = siteSettings.CurrentValue;
    }

    #endregion

    public RegisterLoginViewModel RegisterLogin { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(RegisterLoginViewModel registerLogin)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, PublicConstantStrings.ModelStateErrorMessage);
            return Page();
        }
        var isInputEmail = registerLogin.PhoneNumberOrEmail.IsEmail();
        if (!isInputEmail)
        {
            var addNewUser=false;
            var user = await _userManager.FindByNameAsync(registerLogin.PhoneNumberOrEmail);
            if (user is null)
            {
                user = new User
                {
                    UserName = registerLogin.PhoneNumberOrEmail,
                    PhoneNumber = registerLogin.PhoneNumberOrEmail,
                    Avatar = _siteSettings.UserDefaultAvatar,
                    Email = $"{StringHelpers.GenerateGuid()}testc.com",
                };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    _logger.LogInformation(LogCodes.RegisterCode, $"{user.UserName} created a new account with phone number");
                    addNewUser = true;
                }
                else
                {
                    ModelState.AddErrorsFromResult(result);
                    return Page();
                }
            }
            if (DateTime.Now > user.SendSmsLastTime.AddMinutes(3)|| addNewUser)
            {
                var phoneNumberToken = await _userManager.GenerateChangePhoneNumberTokenAsync(user, registerLogin.PhoneNumberOrEmail);
                //Send Sms token to the user
                var sendSmsResult = await _smsSender.SendSmsAsync(user.PhoneNumber, $"کد فعال سازی شما\n {phoneNumberToken}");
                if (!sendSmsResult)
                {
                    ModelState.AddModelError(string.Empty, "در ارسال پیامک خطایی به وجود آمد. لطفا دوباره سعی نمایید");
                    return Page();
                }
                user.SendSmsLastTime = DateTime.Now;
                await _userManager.UpdateAsync(user);
            }
        }
        return RedirectToPage("./LoginWithPhoneNumber", new { PhoneNumber = registerLogin.PhoneNumberOrEmail });

    }
}
