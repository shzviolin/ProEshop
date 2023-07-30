using Microsoft.AspNetCore.Mvc.Rendering;
using ProEShop.Common.Constants;
using ProEShop.ViewModels.Categories;
using System.ComponentModel.DataAnnotations;

namespace ProEShop.ViewModels.CategoryFeatures;
public class ShowCategoryFeaturesViewModel
{
    public List<ShowCategoryFeatureViewModel> CategoryFeature { get; set; }

    public SearchCategoryFeaturesViewModel SearchCategoryFeatures { get; set; }
    = new();

    public PaginationViewModel Pagination { get; set; }
     = new();
}

public class SearchCategoryFeaturesViewModel
{
    [Display(Name = "دسته بندی")]
    public long CategoryId { get; set; }
    public List<SelectListItem> Categories { get; set; }
}

public class ShowCategoryFeatureViewModel
{
    [Display(Name = "شناسه")]
    public long Id { get; set; }

    [Display(Name = "عنوان")]
    public string Title { get; set; }

    public bool IsDeleted { get; set; }
}


public enum SortingFeatures
{
    [Display(Name = "شناسه")]
    Id,
    [Display(Name = "عنوان")]
    Title,
    [Display(Name = "حذف شده ها")]
    IsDeleted,
}


public enum ShowInMenusStatus
{
    [Display(Name = "همه")]
    All,
    [Display(Name = "بله")]
    True,
    [Display(Name = "خیر")]
    False
}