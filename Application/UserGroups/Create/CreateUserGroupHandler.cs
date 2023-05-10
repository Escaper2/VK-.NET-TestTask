using Application.Abstractions;
using Application.Contracts;
using Application.Exceptions;
using Application.Mapping;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.UserGroup.CreateUserGroup;
namespace Application.UserGroups.Create;

public class CreateUserGroupHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;
    
    public CreateUserGroupHandler(IDatabaseContext context)
    {
        _context = context;
    }
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var userGroup = new UserGroup()
        {
            UserGroupId = request.UserGroupId,
            GroupCode = request.GroupCode,
            Description = request.Description
        };
        if (request.GroupCode == "Admin")
        {
            var adminGroup =
                await _context.UserGroups.FirstOrDefaultAsync(x => x.GroupCode == "Admin", cancellationToken);
            if (adminGroup is not null) throw AdministratorsExcessException.ThrowException();
        }

        await _context.UserGroups.AddAsync(userGroup, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(userGroup.toDto());
    }
}