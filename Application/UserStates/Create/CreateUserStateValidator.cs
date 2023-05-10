using FluentValidation;
using static Application.Contracts.UserState.CreateUserState;
namespace Application.UserStates.Create;

public class CreateUserStateValidator : AbstractValidator<Command>
{
    public CreateUserStateValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.StateCode).Must(x => x is "Active" or "Blocked").WithMessage("StateCode must be Active or Blocked");
    }
}