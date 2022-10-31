
using Microsoft.EntityFrameworkCore;
using ProEshop.DataLayer.Context;
using ProEshop.Entities;
using ProEshop.Services.Contracts;

namespace ProEshop.Services.Services;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : EntityBase, new()
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<TEntity> _entities;

    public GenericService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _entities = unitOfWork.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
        => await _entities.AddAsync(entity);

    public void Update(TEntity entity)
        => _entities.Update(entity);

    public void Remove(TEntity entity)
        => _entities.Remove(entity);
    public void Remove(long id)
    {
        var tEntity = new TEntity();
        var idProperty = typeof(TEntity).GetProperty("Id");
        if (idProperty is null)
            throw new Exception("The entity doesn't have Id field!");
        idProperty.SetValue(tEntity, id, null);
        _unitOfWork.MarkAsDeleted(tEntity);
    }


    public async Task<TEntity> FindByIdAsync(long id)
        => await _entities.FindAsync(id);


    public Task<bool> IsExistByIdAsync(long id)
        => _entities.AnyAsync(x => x.Id == id);



}
