using System.Linq.Expressions;
using FastCommerce.Domain.Common;
using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Entities.Common.Enums;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Catalog.Specifications;

public class ProductsByFilter : Specification<Product>
{
    private readonly DateTime _utcNow;
    private readonly Guid? _categoryId;
    private readonly Guid? _vendorId;
    private readonly EntityStatus _entityStatus;
    private readonly bool _includeInactive;

    public ProductsByFilter(DateTime utcNow, Guid? categoryId, Guid? vendorId, int pageIndex = 0, int pageSize = int.MaxValue,
        EntityStatus entityStatus = EntityStatus.Active, SortDirection sortDirection = SortDirection.Ascending,
        bool includeInactive = true)
    {
        _utcNow = utcNow;
        _categoryId = categoryId;
        _vendorId = vendorId;
        _entityStatus = entityStatus;
        _includeInactive = includeInactive;

        if (categoryId.HasValue)
        {
            AddInclude(x => x.Category!);
        }

        if (vendorId.HasValue)
        {
            AddInclude(x => x.Vendor!);
        }

        ApplyPaging(new PagingModel
        {
            Page = pageIndex,
            PageSize = pageSize,
            SortDirection = sortDirection
        });
    }

    public override Expression<Func<Product, bool>> Criteria => entity => entity.EntityStatus == _entityStatus
        && (!_vendorId.HasValue || entity.Vendor!.Id == _vendorId)
        && (!_categoryId.HasValue || entity.Category!.Id == _categoryId)
        && (_includeInactive || !entity.ActiveTo.HasValue || entity.ActiveTo >= _utcNow);
}
