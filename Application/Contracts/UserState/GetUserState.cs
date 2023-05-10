using Application.Dto;
using MediatR;

namespace Application.Contracts.UserState;

public static class GetUserState
{
    public record struct Command(Guid UserStateId) : IRequest<Response>;

    public record struct Response(UserStateDto UserStateDto);
}