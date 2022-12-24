using Microsoft.EntityFrameworkCore;

namespace ProEShop.Common.EntityFramework;

/// <summary>
/// وقتی ایجاد موجودیت ها را به این صورت پیاده سازی کنیم
/// جمع را برای هر موجودیت در نظر نمی گیرد s
///در بالای کلاس هر موجودیت استفاده میکنیم [Table("table name")] به همین دلیل از 
/// </summary>
public static class EfToolkit
{
    public static void RegisterAllEntities(this ModelBuilder builder, Type type)
    {
        var entities = type.Assembly.GetTypes()
            .Where(x => x.BaseType == type);
        foreach (var entity in entities)
        {
            builder.Entity(entity);
        }
    }
}
