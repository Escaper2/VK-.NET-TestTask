using Application.Abstractions;
using Application.Exceptions;
using Application.Mapping;
using Domain.Models;
using MediatR;
using static Application.Contracts.UserState.GetUserState;
namespace Application.UserStates.Get;

public class GetUserStateHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public GetUserStateHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var userState = await _context.UserStates.FindAsync(new object[] { request.UserStateId }, cancellationToken);
        
        if (userState is null || userState.UserStateId != request.UserStateId) throw NotFoundException<UserState>.ThrowException(request.UserStateId);

        return new Response(userState.toDto());
    }
}
