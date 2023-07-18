using System.Linq.Expressions;
using FastCommerce.Domain.Entities;

namespace FastCommerce.Domain.Interfaces;

public interface IUpdateSpecification<TEntity> where TEntity : class
{
    List<Expression<Func<TEntity, object>>> Includes { get; }
}