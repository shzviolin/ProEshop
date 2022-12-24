using System.ComponentModel.DataAnnotations;

namespace ProEShop.ViewModels.Categories;
public class ShowCategoriesViewModel
{
    public List<ShowCategoryViewModel> Categories { get; set; }
}

public class ShowCategoryViewModel
{
    [Display(Name = "عنوان")]
    public string Title { get; set; }

    [Display(Name = "والد")]
    public string Parent { get; set; }

    [Display(Name = "نمایش در منوهای اصلی")]
    public bool ShoeInMenus { get; set; }
}