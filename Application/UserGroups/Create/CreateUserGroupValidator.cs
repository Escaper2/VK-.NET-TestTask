using Application.Contracts;
using Application.Contracts.UserGroup;
using FluentValidation;

namespace Application.UserGroups.Create;

public class CreateUserGroupValidator : AbstractValidator<CreateUserGroup.Command>
{
    public CreateUserGroupValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.GroupCode).NotEmpty().Must(x => x is "User" or "Admin").WithMessage("GroupCode must be Admin or User");
    }
}