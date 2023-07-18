using System.Linq.Expressions;
using FastCommerce.Domain.Common;

namespace FastCommerce.Domain.Interfaces;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
    string OrderBy { get; }
    SortDirection SortDirection { get; }
    Expression<Func<T, object>> GroupBy { get; }
    int? Take { get; }
    int? Skip { get; }
    bool IgnoreQueryFilter { get; }
    bool IsSatisfiedBy(T obj);
}
