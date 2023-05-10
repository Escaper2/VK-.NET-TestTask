using Application.Dto;
using MediatR;

namespace Application.Contracts.UserState;

public static class GetAllUserStates
{
    public record struct Command() : IRequest<Response>;

    public record struct Response(List<UserStateDto> UserStateDto);
}