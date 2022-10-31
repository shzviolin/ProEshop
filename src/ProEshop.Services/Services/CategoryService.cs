
using Microsoft.EntityFrameworkCore;
using ProEshop.DataLayer.Context;
using ProEshop.Entities;
using ProEshop.Services.Contracts;

namespace ProEshop.Services.Services;

public class CategoryService : GenericService<Category>, ICategoryService
{
    private readonly DbSet<Category> _categories;

    public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _categories = unitOfWork.Set<Category>();
    }

    public Task<List<Category>> GetAll()
    {
        return _categories.ToListAsync();
    }
}
