﻿using ProEShop.Entities;
using ProEShop.ViewModels.Features;

namespace ProEShop.Services.Contracts;

public interface IProvinceAndCityService : IGenericService<ProvinceAndCity>
{
    Task<Dictionary<long, string>> GetProvincesToShowInSelectBoxAsync();
    Task<Dictionary<long, string>> GetCitiesByProvinceIdToShowInSelectBoxAsync(long provinceId);
}
