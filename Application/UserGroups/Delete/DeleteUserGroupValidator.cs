using Application.Contracts;
using FluentValidation;
using static Application.Contracts.UserGroup.DeleteUserGroup;
namespace Application.UserGroups.Delete;

public class DeleteUserGroupValidator : AbstractValidator<Command>
{
    public DeleteUserGroupValidator()
    {
        RuleFor(x => x.UserGroupId).NotEqual(Guid.Empty).WithMessage("Invalid user group id");
    }
}