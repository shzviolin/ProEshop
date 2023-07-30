using ProEShop.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace ProEShop.ViewModels.CategoryFeatures;
public class ShowCategoryFeaturesViewModel
{
    public List<ShowCategoryFeatureViewModel> CategoryFeature { get; set; }

    public PaginationViewModel Pagination { get; set; }
     = new();
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