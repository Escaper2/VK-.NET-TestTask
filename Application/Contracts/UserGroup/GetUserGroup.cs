using Application.Dto;
using MediatR;

namespace Application.Contracts.UserGroup;

public static class GetUserGroup
{
    public record struct Command(Guid UserGroupId) : IRequest<Response>;

    public record struct Response(UserGroupDto UserGroupDto);
}