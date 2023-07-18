using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Vendors;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Vendors.Specifications;

public class VendorAccountById : Specification<VendorAccount>
{
    private readonly Guid _userId;
    private readonly Guid _vendorId;

    public VendorAccountById(Guid userId, Guid vendorId)
    {
        _userId = userId;
        _vendorId = vendorId;
        AddInclude(x => x.Vendor!);
        AddInclude("AccountRoles.Role");
    }

    public override Expression<Func<VendorAccount, bool>> Criteria => 
        x => x.Id == _userId && x.Vendor!.Id == _vendorId;
}
