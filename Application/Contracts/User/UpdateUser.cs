using Application.Dto;
using MediatR;

namespace Application.Contracts.User;

public static class UpdateUser
{
    public record struct Command(Guid UserId, string Login, string Password, string Name) : IRequest<Response>;

    public record struct Response(UserDto UserDto);
}