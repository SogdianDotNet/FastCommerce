using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Catalog.Specifications;

public class ProductsByFilter : Specification<Product>
{
    private readonly Guid _categoryId;
    private readonly Guid? _vendorId;

    public ProductsByFilter(Guid categoryId, Guid? vendorId)
    {
        _categoryId = categoryId;
        _vendorId = vendorId;
        AddInclude(x => x.Category!);
        if (vendorId.HasValue)
        {
            AddInclude(x => x.Vendor!);
        }
    }

    public override Expression<Func<Product, bool>> Criteria => entity => entity.EntityStatus == FastCommerce.Domain.Entities.Common.Enums.EntityStatus.Active
        && (!_vendorId.HasValue || entity.Vendor!.Id == _vendorId)
        && entity.Category!.Id == _categoryId;
}
