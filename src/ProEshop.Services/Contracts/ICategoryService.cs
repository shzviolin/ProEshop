using ProEshop.Entities;

namespace ProEshop.Services.Contracts;

public interface ICategoryService : IGenericService<Category>
{
    Task<List<Category>> GetAll();
}
