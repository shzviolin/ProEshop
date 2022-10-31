﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProEshop.Entities;
using ProEshop.Entities.AuditableEntity;
using ProEshop.Entities.Identity;
using System.Globalization;

namespace ProEshop.DataLayer.Context;

/// <summary>
/// شده من استفاده کن Customize میگیم که از کلاسهای Identity به سیستم  
/// </summary>
public class ApplicationDbContext :
    IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<Category> Categories { get; set; }


    public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
    {
        var value = this.Entry(entity).Property(propertyName).CurrentValue;
        return value != null
            ? (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture)
            : default;
    }


    public object GetShadowPropertyValue(object entity, string propertyName)
    {
        return this.Entry(entity).Property(propertyName).CurrentValue;
    }

    public void MarkAsDeleted<TEntity>(TEntity entity)
        => base.Entry(entity).State = EntityState.Deleted;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetShadowProperties();
        return base.SaveChangesAsync(cancellationToken);
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //All configurations we set in Configuration will set 
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        //This should be placed here, at the end.
        builder.AddAuditableShadowProperties();
    }


    private void SetShadowProperties()
    {
        //we can't constructor injection anymore, because we are using the `AddDbContextPool<>`
        var props = this.GetService<IHttpContextAccessor>()?.GetShadowProperties();
        ChangeTracker.SetAuditableEntityPropertyValues(props);
    }
}