using ProEshop.Entities;

namespace ProEshop.Services.Contracts;

public interface IGenericService<TEntity> where TEntity : EntityBase, new()
{
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void Remove(long id);
    Task<TEntity> FindByIdAsync(long id);
    Task<bool> IsExistByIdAsync(long id);
}
