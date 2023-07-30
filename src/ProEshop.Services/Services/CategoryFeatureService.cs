using Microsoft.EntityFrameworkCore;
using ProEShop.Common.Helpers;
using ProEShop.DataLayer.Context;
using ProEShop.Entities;
using ProEShop.Services.Contracts;
using ProEShop.ViewModels.Categories;
using ProEShop.ViewModels.CategoryFeatures;

namespace ProEShop.Services.Services;

public class CategoryFeatureService : GenericService<Category>, ICategoryFeatureService
{
    private readonly DbSet<CategoryFeature> _categoryFeatures;
    public CategoryFeatureService(IUnitOfWork uow)
        : base(uow)
    {
        _categoryFeatures = uow.Set<CategoryFeature>();
    }

    public Task<ShowCategoryFeatureViewModel> GetCategoryFeatures(ShowCategoriesViewModel model)
    {
        throw new NotImplementedException();
    }
}

