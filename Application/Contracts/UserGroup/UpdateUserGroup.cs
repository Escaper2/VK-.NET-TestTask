using Application.Dto;
using MediatR;

namespace Application.Contracts.UserGroup;

public static class UpdateUserGroup
{
    public record struct Command(Guid UserGroupId, string GroupCode, string Description) : IRequest<Response>;

    public record struct Response(UserGroupDto UserGroupDto);
}