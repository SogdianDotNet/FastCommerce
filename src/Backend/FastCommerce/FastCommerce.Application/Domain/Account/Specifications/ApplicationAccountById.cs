using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Account;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Account.Specifications;

internal class ApplicationAccountById : Specification<ApplicationAccount>
{
    private readonly Guid _id;

    public ApplicationAccountById(Guid id, bool includeRoles = false)
    {
        _id = id;
        if (includeRoles)
        {
            AddInclude("AccountRoles.Role");
        }
        AddInclude(x => x.Permissions!);
        AddInclude(x => x.ActivityLogs!);
    }

    public override Expression<Func<ApplicationAccount, bool>> Criteria => entity => entity.Id == _id;
}
