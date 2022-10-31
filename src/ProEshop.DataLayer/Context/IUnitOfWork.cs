using Microsoft.EntityFrameworkCore;

namespace ProEshop.DataLayer.Context
{
    /// <summary>
    /// Because SaveChanges() and SaveChangesAsync() are exist in IdentityDbContext, it doesn't need to implement them in ApplicationDbContext
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible;
        object GetShadowPropertyValue(object entity, string propertyName);
        void MarkAsDeleted<TEntity>(TEntity entity);
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
