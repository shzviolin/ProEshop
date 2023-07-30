using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProEShop.Common.Constants;
using ProEShop.Common.Helpers;
using ProEShop.DataLayer.Context;
using ProEShop.Services.Contracts;
using ProEShop.Common.IdentityToolkit;
using ProEShop.ViewModels.CategoryFeatures;
using ProEShop.Common;

namespace ProEShop.Web.Pages.Admin.CategoryFeature
{
    public class IndexModel : PageBase
    {
        #region Constructor
        private readonly ICategoryFeatureService _categoryFeatureService;
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _uow;

        public IndexModel(
            ICategoryFeatureService categoryFeatureService,
            ICategoryService categoryService,
            IUnitOfWork uow)
        {
            _categoryFeatureService = categoryFeatureService;
            _categoryService = categoryService;
            _uow = uow;
        }
        #endregion

        public ShowCategoryFeaturesViewModel categoryFeatures { get; set; }
        = new();
        public async Task OnGet()
        {
            var categories = await _categoryService.GetCategoriesToShowInSelectBoxAsync();
            categoryFeatures.SearchCategoryFeatures.Categories = categories.CreateSelectListItem();
        }

        public async Task<IActionResult> OnGetGetDataTableAsync(ShowCategoryFeaturesViewModel categoryFeatures)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonResultOperation(false, PublicConstantStrings.ModelStateErrorMessage)
                {
                    Data = ModelState.GetModelStateErrors()
                });
            }
            return Partial("List", await _categoryFeatureService.GetCategoryFeatures(categoryFeatures));
        }
    }
}
