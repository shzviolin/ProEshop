using Microsoft.EntityFrameworkCore;
using ProEShop.DataLayer.Context;
using ProEShop.Entities;
using ProEShop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEShop.Services.Services;
public class ProvinceAndCityService : CustomGenericService<ProvinceAndCity>, IProvinceAndCityService
{
    private readonly DbSet<ProvinceAndCity> _provinceAndCities;
    public ProvinceAndCityService(IUnitOfWork uow) : base(uow)
    {
        _provinceAndCities = uow.Set<ProvinceAndCity>();
    }

    public async Task<Dictionary<long, string>> GetProvincesToShowInSelectBoxAsync()
    {
        return await _provinceAndCities.Where(x => x.ParentId == null)
             .ToDictionaryAsync(x => x.Id, x => x.Title);
    }
}
