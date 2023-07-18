using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Common.Enums;
using FastCommerce.Domain.Entities.Vendors;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Vendors.Specifications;

internal class VendorAccountsByVendorId : Specification<VendorAccount>
{
    private readonly Guid _vendorId;
    private readonly EntityStatus _entityStatus;

    public VendorAccountsByVendorId(Guid vendorId, EntityStatus entityStatus)
    {
        _vendorId = vendorId;
        _entityStatus = entityStatus;
        AddInclude("AccountRoles.Role");
        AddInclude(x => x.Vendor!);
    }

    public override Expression<Func<VendorAccount, bool>> Criteria => entity => entity.Vendor!.Id == _vendorId && entity.EntityStatus == _entityStatus;
}
