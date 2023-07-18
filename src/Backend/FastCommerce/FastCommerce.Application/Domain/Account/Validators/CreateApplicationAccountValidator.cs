using FastCommerce.Application.Domain.Account.Dtos;
using FluentValidation;

namespace FastCommerce.Application.Domain.Account.Validators;

public class CreateApplicationAccountValidator : AbstractValidator<ApplicationAccountDto>
{
    public CreateApplicationAccountValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Role).NotEmpty();
    }
}
