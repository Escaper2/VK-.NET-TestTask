using Application.Contracts;
using FluentValidation;
using static Application.Contracts.User.GetUser;
namespace Application.Users.Get;

public class GetUserValidator : AbstractValidator<Command>
{
    public GetUserValidator()
    {
        RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Invalid user id");
    }
}