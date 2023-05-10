using Application.Dto;
using MediatR;

namespace Application.Contracts.UserGroup;

public static class GetAllUserGroups
{
    public record struct Command() : IRequest<Response>;

    public record struct Response(List<UserGroupDto> UserGroupDtos);
}