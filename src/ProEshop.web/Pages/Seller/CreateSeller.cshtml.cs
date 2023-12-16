using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProEShop.Common;
using ProEShop.Entities.Identity;
using ProEShop.Services.Contracts;
using ProEShop.Services.Contracts.Identity;
using ProEShop.ViewModels.Sellers;

namespace ProEShop.Web.Pages.Seller;

public class CreateSellerModel : PageModel
{
    #region Constructor
    private readonly IApplicationUserManager _userManager;
    private readonly IProvinceAndCityService _provinceAndCity;

    public CreateSellerModel(IApplicationUserManager userManager, IProvinceAndCityService provinceAndCityService)
    {
        _userManager = userManager;
        _provinceAndCity = provinceAndCityService;
    }
    #endregion

    [BindProperty]
    public CreateSellerViewModel CreateSeller { get; set; }
        = new();

    public async Task<IActionResult> OnGet(string phoneNumber)
    {
        if (!await _userManager.CheckForUserIsSeller(phoneNumber))
        {
            return RedirectToPage("/Error");
        }

        CreateSeller.PhoneNumber = phoneNumber;
        var provinces = await _provinceAndCity.GetProvincesToShowInSelectBoxAsync();
        CreateSeller.Provinces = provinces.CreateSelectListItem();
        return Page();
    }

    public void OnPost()
    {
        //await _signInManager.SignInAsync(user, true);
    }
}
