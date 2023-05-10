using Application.Dto;
using MediatR;

namespace Application.Contracts.User;

public static class GetAllUsers
{
    public record struct Command() : IRequest<Response>;

    public record struct Response(List<UserDto> UserDtos);
}