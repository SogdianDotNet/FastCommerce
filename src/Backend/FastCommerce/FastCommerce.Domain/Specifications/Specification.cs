using System.Linq.Expressions;
using FastCommerce.Domain.Common;
using FastCommerce.Domain.Entities;
using FastCommerce.Domain.Interfaces;

namespace FastCommerce.Domain.Specifications;

public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : IEntity
{
    private Func<TEntity, bool> _compiledCriteria;
    private Func<TEntity, bool> CompiledCriteria => _compiledCriteria ??= Criteria.Compile();

    public abstract Expression<Func<TEntity, bool>> Criteria { get; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();
    public List<string> IncludeStrings { get; } = new List<string>();
    public string? OrderBy { get; private set; }
    public SortDirection SortDirection { get; private set; }
    public Expression<Func<TEntity, object>>? GroupBy { get; private set; }
    public int? Take { get; private set; }
    public int? Skip { get; private set; }

    public bool IgnoreQueryFilter { get; private set; }

    public bool IsSatisfiedBy(TEntity obj)
    {
        return CompiledCriteria(obj);
    }

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        Expression<Func<TEntity, bool>> filterExpression = x => !x.IsDeleted && !x.DeletedUtc.HasValue;
        Expression<Func<TEntity, object>> combinedExpression = PredicateBuilder.AndAlso(includeExpression, filterExpression);
        Includes.Add(combinedExpression);
    }

    protected void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }

    protected void ApplyPaging(PagingModel pagingModel)
    {
        Skip = pagingModel.Page * pagingModel.PageSize;
        Take = pagingModel.PageSize;
    }

    protected void ApplyOrderBy(string orderBy, SortDirection sortDirection = SortDirection.Ascending)
    {
        OrderBy = orderBy;
        SortDirection = sortDirection;
    }


    protected void ApplyGroupBy(Expression<Func<TEntity, object>> groupByExpression)
    {
        GroupBy = groupByExpression;
    }

    protected void SetIgnoreQueryFilter(bool ingoreQueryFilter = true)
    {
        IgnoreQueryFilter = ingoreQueryFilter;
    }
}
