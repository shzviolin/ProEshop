using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProEShop.Common.Helpers;
public static class ExpressionHelpers
{

    public static Expression<Func<T, bool>> CreateExpression<T>(string propertyName, object propertyValue)
    {
        var parameter = Expression.Parameter(typeof(T));
        var property = Expression.Property(parameter, propertyName);
        if (propertyValue is string)
            propertyValue = propertyValue.ToString()?.Trim();
        var constantValue = Expression.Constant(propertyValue);
        var equal = Expression.Equal(property, constantValue);
        return Expression.Lambda<Func<T, bool>>(equal, parameter);
    }

    public static IOrderedQueryable<T> CreateOrderByExpression<T>(this IQueryable<T> query, string propertyName, string isAsc)
    {
        var parameter = Expression.Parameter(typeof(T),"x");
        var conversion = Expression.Convert(Expression.Property(parameter, propertyName), typeof(object));
        var expresion = Expression.Lambda<Func<T, object>>(conversion, parameter);
        IOrderedQueryable<T> result = null;
        result = isAsc == "Asc" ? query.OrderBy(expresion) : query.OrderByDescending(expresion);
        return result;
    }
}
