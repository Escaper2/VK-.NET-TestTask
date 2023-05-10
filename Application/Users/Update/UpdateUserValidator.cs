using FluentValidation;
using static Application.Contracts.User.UpdateUser;
namespace Application.Users.Update;

public class UpdateUserValidator : AbstractValidator<Command>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Login).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
    }
}