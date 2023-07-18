using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Catalog.Specifications;

internal class AnyCategoryNameExist : Specification<Category>
{
    private readonly string? _name;
    private readonly Guid? _excludeCategoryId;

    public AnyCategoryNameExist(string? name, Guid? excludeCategoryId = null)
    {
        _name = name?.ToLower();
        _excludeCategoryId = excludeCategoryId;
    }

    public override Expression<Func<Category, bool>> Criteria => entity => entity.Name == _name && (!_excludeCategoryId.HasValue || entity.Id != _excludeCategoryId);
}
