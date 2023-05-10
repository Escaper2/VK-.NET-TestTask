using Application.Abstractions;
using Application.Exceptions;
using Application.Mapping;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.UserGroup.GetAllUserGroups;
namespace Application.UserGroups.Get;

public class GetAllUserGroupsHandler : IRequestHandler<Command,Response>
{
    private readonly IDatabaseContext _context;

    public GetAllUserGroupsHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var userGroups = await _context.UserGroups.Select(x => x.toDto()).ToListAsync(cancellationToken);
        return new Response(userGroups);
    }
}