﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProEShop.Common.Attributes;
using ProEShop.Common.Constants;
using ProEShop.Entities;
using ProEShop.Entities.Identity;
using System.ComponentModel.DataAnnotations;
namespace ProEShop.ViewModels.Sellers;

public class CreateSellerViewModel
{
    [Display(Name = "نام")]
    [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF\s]*$", ErrorMessage = "لطفا تنها از حروف فارسی استفاده نمائید")]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(200, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF\s]*$", ErrorMessage = "لطفا تنها از حروف فارسی استفاده نمائید")]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(200, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string LastName { get; set; }

    [Display(Name = "کد ملی")]
    [LtrDirectionAttribute]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(10, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string NationalCode { get; set; }

    [Display(Name = "تاریخ تولد")]
    [LtrDirectionAttribute]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    public string BirthDate { get; set; }
    public string BirthDateEnglish { get; set; }

    [Display(Name = "جنسیت")]
    public Gender Gender { get; set; }

    [Display(Name = "شماره تلفن")]
    [LtrDirectionAttribute]
    [HiddenInput]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    public string PhoneNumber { get; set; }

    public bool IsLegalPerson { get; set; }

    [Display(Name = "نام شرکت")]
    [MaxLength(200, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string CompanyName { get; set; }

    [Display(Name = "شماره ثبت شرکت")]
    [MaxLength(100, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string RegisterNumber { get; set; }

    [Display(Name = "کد اقتصادی")]
    [LtrDirectionAttribute]
    [MaxLength(12, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string EconomicCode { get; set; }

    [Display(Name = "نام افراد دارای حق امضا")]
    [MaxLength(300, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string SignatureOwners { get; set; }

    [Display(Name = "شناسه ملی")]
    [LtrDirectionAttribute]
    [RegularExpression(@"^[\d]+$", ErrorMessage = AttributesErrorMessages.RegularExpressionMessage)]
    [MaxLength(30, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string NationalId { get; set; }

    [Display(Name = "نوع شرکت")]
    public CompanyType? CompanyType { get; set; }


    [Display(Name = "درباره فروشگاه")]
    public string AboutSeller { get; set; }

    [Display(Name = "لوگو فروشگاه")]
    [IsImage("لوگو فروشگاه")]
    [MaxFileSize("لوگو فروشگاه", 1)]
    public IFormFile Logo { get; set; }

    /// <summary>
    /// عکس کارت ملی
    /// </summary>
    [Display(Name = "تصویر کارت ملی")]
    [FileRequired("تصویر کارت ملی")]
    [IsImage("تصویر کارت ملی")]
    [MaxFileSize("تصویر کارت ملی", 1)]
    public IFormFile IdCartPicture { get; set; }

    [Display(Name = "شماره شبا")]
    [LtrDirectionAttribute]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(24, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string ShabaNumber { get; set; }

    [Display(Name = "شماره تلفن")]
    [LtrDirectionAttribute]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(11, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    [RegularExpression(@"^0[\d]{10}$", ErrorMessage = AttributesErrorMessages.RegularExpressionMessage)]
    public string Telephone { get; set; }

    [Display(Name = "آدرس وبسایت")]
    [LtrDirectionAttribute]
    [MaxLength(200, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string Website { get; set; }

    [Display(Name = "استان")]
    [Range(1, long.MaxValue, ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    public long ProvinceId { get; set; }

    [Display(Name = "شهرستان")]
    [Range(1, long.MaxValue, ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    public long CityId { get; set; }

    [Display(Name = "آدرس کامل")]
    [Required(ErrorMessage = "لطفاآدرس را وارد نمایید")]
    [MaxLength(300, ErrorMessage = "آدرس نباید بیشتر از {1} کاراکتر باشد")]
    public string Address { get; set; }

    [Display(Name = "کد پستی")]
    [LtrDirectionAttribute]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(10, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    [RegularExpression(@"[\d]{10}$", ErrorMessage = AttributesErrorMessages.RegularExpressionMessage)]
    public string PostalCode { get; set; }

    public List<SelectListItem> Provinces { get; set; }

    [Display(Name = "قوانین و قرارداد را به صورت کامل خوانده و قبول دارم")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "شما باید قوانین و مقررات را تایید نمایید")]
    public bool AcceptTerms { get; set; }
}
