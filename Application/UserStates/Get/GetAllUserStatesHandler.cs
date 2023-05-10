using Application.Abstractions;
using Application.Contracts.UserState;
using Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.UserState.GetAllUserStates;
namespace Application.UserStates.Get;

public class GetAllUserStatesHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public GetAllUserStatesHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var userStates = await _context.UserStates.Select(x => x.toDto()).ToListAsync(cancellationToken);

        return new Response(userStates);
    }
}