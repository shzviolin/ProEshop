﻿using Microsoft.AspNetCore.Mvc.Rendering;
using ProEShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEShop.ViewModels.Features;
public class AddFeatureViewModel
{
    [Display(Name = "عنوان ویژگی")]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(150, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string Title { get; set; }

    public List<SelectListItem> Categories { get; set; }

    [Display(Name = "دسته بندی")]
    [Range(1, long.MaxValue, ErrorMessage = AttributesErrorMessages.ComboBoxRequiredMessage)]
    public long CategoryId { get; set; }
}
