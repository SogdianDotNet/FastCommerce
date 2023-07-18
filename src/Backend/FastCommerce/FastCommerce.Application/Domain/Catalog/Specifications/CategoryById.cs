using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Entities.Common.Enums;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Catalog.Specifications;

public class CategoryById : Specification<Category>
{
    private readonly Guid _categoryId;

    public CategoryById(Guid categoryId)
    {
        _categoryId = categoryId;
    }

    public override Expression<Func<Category, bool>> Criteria => entity => entity.Id == _categoryId && !entity.IsActive && entity.EntityStatus == EntityStatus.Active;
}
