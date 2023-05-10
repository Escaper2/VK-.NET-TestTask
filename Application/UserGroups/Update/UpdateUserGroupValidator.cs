using Application.Contracts;
using FluentValidation;
using static Application.Contracts.UserGroup.UpdateUserGroup;
namespace Application.UserGroups.Update;

public class UpdateUserGroupValidator : AbstractValidator<Command>
{
    public UpdateUserGroupValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.GroupCode).NotEmpty().Must(x => x is "User" or "Admin").WithMessage("GroupCode must be Admin or User");
    }
}