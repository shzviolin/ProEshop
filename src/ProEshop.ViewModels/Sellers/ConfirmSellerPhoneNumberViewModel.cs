﻿using Microsoft.AspNetCore.Mvc;
using ProEShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEShop.ViewModels.Sellers;
public class ConfirmSellerPhoneNumberViewModel
{
    [Display(Name = "کد فعال سازی")]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [RegularExpression(@"[\d]{6}", ErrorMessage = AttributesErrorMessages.RegularExpressionMessage)]
    [MaxLength(6, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string ActivationCode { get; set; }

    [Display(Name = "شماره تلفن")]
    [HiddenInput]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    public string PhoneNumber { get; set; }

    public byte SendSmsLastTimeMinute { get; set; }

    public byte SendSmsLastTimeSecond { get; set; }
}
