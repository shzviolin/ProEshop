using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProEShop.Common.Constants;
using ProEShop.Common.Helpers;
using ProEShop.DataLayer.Context;
using ProEShop.Services.Contracts;
using ProEShop.Common.IdentityToolkit;
using ProEShop.ViewModels.Features;
using ProEShop.Common;

namespace ProEShop.Web.Pages.Admin.Feature
{
    public class IndexModel : PageBase
    {
        #region Constructor
        private readonly IFeatureService _featureService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryFeatureService _categoryFeatureService;
        private readonly IUnitOfWork _uow;

        public IndexModel(
            IFeatureService featureService,
            ICategoryService categoryService,
            ICategoryFeatureService categoryFeatureService,
            IUnitOfWork uow)
        {
            _featureService = featureService;
            _categoryService = categoryService;
            _categoryFeatureService = categoryFeatureService;
            _uow = uow;
        }
        #endregion

        public ShowFeaturesViewModel Features { get; set; }
        = new();
        public async Task OnGet()
        {
            var categories = await _categoryService.GetCategoriesToShowInSelectBoxAsync();
            Features.SearchFeatures.Categories = categories.CreateSelectListItem();
        }

        public async Task<IActionResult> OnGetGetDataTableAsync(ShowFeaturesViewModel features)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonResultOperation(false, PublicConstantStrings.ModelStateErrorMessage)
                {
                    Data = ModelState.GetModelStateErrors()
                });
            }
            return Partial("List", await _featureService.GetFeatures(features));
        }

        public async Task<IActionResult> OnPostDelete(long categoryId, long featureId)
        {
            var categoryFeature = await _categoryFeatureService.GetCategoryFeatureToRemove(categoryId, featureId);
            if (categoryFeature is not null)
            {
                _categoryFeatureService.Remove(categoryFeature);
                await _uow.SaveChangesAsync();
            }
            return Json(new JsonResultOperation(true, "????? ???? ???? ???? ??? ?? ?????? ??? ??"));
        }
    }
}
