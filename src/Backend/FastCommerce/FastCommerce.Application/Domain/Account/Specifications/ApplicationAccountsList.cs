using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Account;
using FastCommerce.Domain.Entities.Common.Enums;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Account.Specifications;

internal class ApplicationAccountsList : Specification<ApplicationAccount>
{
    private readonly EntityStatus _entityStatus;

    public ApplicationAccountsList(EntityStatus entityStatus)
    {
        _entityStatus = entityStatus;
    }

    public override Expression<Func<ApplicationAccount, bool>> Criteria => entity => entity.EntityStatus == _entityStatus;
}
