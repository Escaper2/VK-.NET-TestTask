using Application.Abstractions;
using Application.Mapping;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using static Application.Contracts.UserState.CreateUserState;
namespace Application.UserStates.Create;

public class CreateUserStateHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateUserStateHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var userState = new UserState()
        {
            UserStateId = request.UserStateId,
            StateCode = request.StateCode,
            Description = request.Description
        };

        await _context.UserStates.AddAsync(userState, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(userState.toDto());
    }
}