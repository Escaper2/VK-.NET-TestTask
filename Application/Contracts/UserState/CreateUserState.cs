using Application.Dto;
using MediatR;

namespace Application.Contracts.UserState;

public static class CreateUserState
{
    public record struct Command(Guid UserStateId, string StateCode, string Description) : IRequest<Response>;

    public record struct Response(UserStateDto UserStateDto);
}