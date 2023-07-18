using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Entities.Common.Enums;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Catalog.Specifications;

public class ActiveCategories : Specification<Category>
{
    public override Expression<Func<Category, bool>> Criteria => entity => entity.IsActive && entity.EntityStatus == EntityStatus.Active;
}
