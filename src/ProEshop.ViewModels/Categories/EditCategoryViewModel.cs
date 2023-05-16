using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProEShop.Common.Attributes;
using ProEShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEShop.ViewModels.Categories;
public class EditCategoryViewModel : AddCategoryViewModel
{
    [HiddenInput]
    public long Id { get; set; }

    [Display(Name ="تصویر انتخاب شده")]
    public string SelectedPicture { get; set; }
}
