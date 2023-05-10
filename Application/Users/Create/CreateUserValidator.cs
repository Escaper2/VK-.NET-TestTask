using FluentValidation;
using static Application.Contracts.User.CreateUser;
namespace Application.Users.Create;

public class CreateUserValidator : AbstractValidator<Command>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Login).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
        RuleFor(x => x.CreatedDate).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
    }
}