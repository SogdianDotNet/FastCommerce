using System.Linq.Expressions;

namespace FastCommerce.Domain.Specifications;

public static class PredicateBuilder
{
    public static Expression<Func<T, object>> AndAlso<T>(Expression<Func<T, object>> left, Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));
        var propertyAccess = Expression.Invoke(left, parameter);
        var lambda = Expression.Lambda<Func<T, object>>(Expression.AndAlso(propertyAccess, right.Body), parameter);
        return lambda;
    }
}