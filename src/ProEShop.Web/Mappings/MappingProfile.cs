﻿using AutoMapper;
using ProEShop.Entities.Identity;
using ProEShop.ViewModels.Sellers;

namespace ProEShop.Web.Mappings;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<User, CreateSellerViewModel>();
    }
}
