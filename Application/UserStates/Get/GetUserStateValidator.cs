using FluentValidation;
using static Application.Contracts.UserState.GetUserState;
namespace Application.UserStates.Get;

public class GetUserStateValidator : AbstractValidator<Command>
{
    public GetUserStateValidator()
    {
        RuleFor(x => x.UserStateId).NotEqual(Guid.Empty).WithMessage("Invalid user state id");
    }
}