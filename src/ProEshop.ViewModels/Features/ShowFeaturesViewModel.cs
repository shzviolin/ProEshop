using Microsoft.AspNetCore.Mvc.Rendering;
using ProEShop.Common.Constants;
using ProEShop.ViewModels.Categories;
using System.ComponentModel.DataAnnotations;

namespace ProEShop.ViewModels.Features;
public class ShowFeaturesViewModel
{
    public List<ShowFeatureViewModel> Features { get; set; }

    public SearchFeaturesViewModel SearchFeatures { get; set; }
    = new();

    public PaginationViewModel Pagination { get; set; }
     = new();
}

public class SearchFeaturesViewModel
{
    [Display(Name = "دسته بندی")]
    public long CategoryId { get; set; }

    [MaxLength(150, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    [Display(Name = "عنوان")]
    public string Title { get; set; }
    public List<SelectListItem> Categories { get; set; }

    [Display(Name = "نمایش بر اساس")]
    public SortingFeatures Sorting { get; set; }

    [Display(Name = "مرتب سازی بر اساس ")]
    public SortingOrder SortingOrder { get; set; }
}

public class ShowFeatureViewModel
{
    [Display(Name = "عنوان")]
    public string Title { get; set; }
}


public enum SortingFeatures
{
    [Display(Name = "شناسه")]
    Id,
    [Display(Name = "عنوان")]
    Title,
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