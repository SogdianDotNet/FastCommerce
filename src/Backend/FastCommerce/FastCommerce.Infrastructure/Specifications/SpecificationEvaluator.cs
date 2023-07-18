using FastCommerce.Domain.Entities;
using FastCommerce.Domain.Interfaces;
using FastCommerce.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FastCommerce.Infrastructure.Specifications;

public static class SpecificationEvaluator<TEntity> where TEntity : class
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification, bool applyPaging)
    {
        var query = inputQuery
                .Where(x => !((IEntity)x).IsDeleted && !((IEntity)x).DeletedUtc.HasValue);

        if (specification.Criteria != null)
        {
            query = query
                .Where(specification.Criteria);
        }

        query = specification.Includes
            .Aggregate(query, (current, include) => current.Include(include));

        query = specification.IncludeStrings
            .Aggregate(query, (current, include) => current.Include(include));

        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy, specification.SortDirection);
        }

        if (specification.GroupBy != null)
        {
            query = query
                .GroupBy(specification.GroupBy).SelectMany(group => group);
        }

        if (applyPaging && specification.Skip.HasValue && specification.Take.HasValue)
        {
            query = query
                .Skip(specification.Skip.Value)
                .Take(specification.Take.Value);
        }

        if (specification.IgnoreQueryFilter)
        {
            query = query.IgnoreQueryFilters();
        }

        return query;
    }
}
