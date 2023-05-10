using FluentValidation;
using static Application.Contracts.User.DeleteUser;
namespace Application.Users.Delete;

public class DeleteUserValidator : AbstractValidator<Command>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("Invalid user id");
    }
}