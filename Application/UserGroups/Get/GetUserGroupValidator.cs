using Application.Contracts;
using FluentValidation;
using static Application.Contracts.UserGroup.GetUserGroup;
namespace Application.UserGroups.Get;

public class GetUserGroupValidator : AbstractValidator<Command>
{
    public GetUserGroupValidator()
    {
        RuleFor(x => x.UserGroupId).NotEqual(Guid.Empty).WithMessage("Invalid user group id");
    }
}