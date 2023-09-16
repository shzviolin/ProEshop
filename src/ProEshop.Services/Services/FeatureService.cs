﻿using Microsoft.EntityFrameworkCore;
using ProEShop.Common.Helpers;
using ProEShop.DataLayer.Context;
using ProEShop.Entities;
using ProEShop.Services.Contracts;
using ProEShop.ViewModels.Features;

namespace ProEShop.Services.Services;

public class FeatureService : GenericService<Feature>, IFeatureService
{
    private readonly DbSet<Feature> _features;
    public FeatureService(IUnitOfWork uow)
        : base(uow)
    {
        _features = uow.Set<Feature>();
    }


    public async Task<ShowFeaturesViewModel> GetFeatures(ShowFeaturesViewModel model)
    {
        var features = _features.AsQueryable();

        var searchedTitle = model.SearchFeatures.Title;
        if (!string.IsNullOrWhiteSpace(searchedTitle))
            features = features.Where(x => x.Title.Contains(searchedTitle));

        features = features.SelectMany(x => x.CategoryFeatures)
            .Where(x => x.CategoryId == model.SearchFeatures.CategoryId)
            .Select(x => x.Feature);

        features = features.CreateOrderByExpression(model.SearchFeatures.Sorting.ToString(), model.SearchFeatures.SortingOrder.ToString());

        var paginationResult = await GenericPaginationAsync(features, model.Pagination);

        return new()
        {
            Features = await paginationResult.Query
            .Select(x => new ShowFeatureViewModel
            {
                Title = x.Title,
                CategoryId = model.SearchFeatures.CategoryId,
                FeatureId = x.Id
            })
            .ToListAsync(),
            Pagination = paginationResult.pagination
        };
    }
}

