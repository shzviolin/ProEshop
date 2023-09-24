﻿using ProEShop.Entities;
using ProEShop.ViewModels.Features;

namespace ProEShop.Services.Contracts;

public interface IFeatureService : IGenericService<Feature>
{
    Task<ShowFeaturesViewModel> GetFeatures(ShowFeaturesViewModel model);
    Task<Feature> FindByTitleAsync(string title);
    Task<List<string>> AutocompleteSearch(string input);
}