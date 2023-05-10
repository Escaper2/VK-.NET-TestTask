using Application.Dto;
using MediatR;

namespace Application.Contracts.User;

public static class GetUser
{
    public record struct Command(Guid UserId) : IRequest<Response>;

    public record struct Response(UserDto UserDto);
}