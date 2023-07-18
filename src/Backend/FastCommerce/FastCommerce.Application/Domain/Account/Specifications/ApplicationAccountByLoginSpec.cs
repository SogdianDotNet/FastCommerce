using System.Linq.Expressions;
using FastCommerce.Domain.Entities.Account;
using FastCommerce.Domain.Specifications;

namespace FastCommerce.Application.Domain.Account.Specifications;

internal class ApplicationAccountByLoginSpec : Specification<ApplicationAccount>
{
    private readonly string _userNameOrEmail;
    private readonly bool _isEmail;

    public ApplicationAccountByLoginSpec(string userNameOrEmail, bool isEmail)
    {
        _userNameOrEmail = userNameOrEmail;
        _isEmail = isEmail;
        AddInclude(x => x.ActivityLogs!);
    }

    public override Expression<Func<ApplicationAccount, bool>> Criteria =>
        entity => _isEmail ? entity.Email == _userNameOrEmail : entity.UserName == _userNameOrEmail;
}
