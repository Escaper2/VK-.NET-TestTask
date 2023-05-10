using Application.Dto;
using MediatR;

namespace Application.Contracts.User;

public static class CreateUser
{
    public record struct Command(Guid UserId, string Login, string Password, DateOnly CreatedDate, Guid UserGroupId, Guid UserStateId,
        string Name, string StateCode, string StateDescription) : IRequest<Response>;

    public record struct Response(UserDto User);
}