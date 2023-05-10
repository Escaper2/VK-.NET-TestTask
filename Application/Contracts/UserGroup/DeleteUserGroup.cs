using Application.Dto;
using MediatR;

namespace Application.Contracts.UserGroup;

public static class DeleteUserGroup
{
    public record struct Command(Guid UserGroupId) : IRequest<Response>;

    public record struct Response(UserGroupDto UserGroupDto);
}