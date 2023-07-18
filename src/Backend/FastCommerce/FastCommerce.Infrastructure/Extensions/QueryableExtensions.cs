using System.Linq.Expressions;
using FastCommerce.Domain.Common;

namespace FastCommerce.Infrastructure.Extensions;

public static class QueryableExtensions
{
    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortBy) => query.OrderBy(sortBy, SortDirection.Ascending);
    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortBy, SortDirection direction)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }
        if (string.IsNullOrWhiteSpace(sortBy))
        {
            throw new ArgumentNullException(nameof(sortBy));
        }

        var param = Expression.Parameter(typeof(T));
        var body = sortBy.Split('.').Aggregate<string, Expression>(param, Expression.PropertyOrField);

        return (IOrderedQueryable<T>)query.Provider.CreateQuery(
            Expression.Call(
                typeof(Queryable),
                direction == SortDirection.Ascending ? "OrderBy" : "OrderByDescending",
                new[] { typeof(T), body.Type },
                query.Expression,
                Expression.Lambda(body, param)
            )
        );
    }
    public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string sortBy) => query.OrderBy(sortBy, SortDirection.Descending);
}
