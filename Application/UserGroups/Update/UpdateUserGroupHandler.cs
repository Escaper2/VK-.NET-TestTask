using Application.Abstractions;
using Application.Contracts;
using Application.Exceptions;
using Application.Mapping;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.UserGroup.UpdateUserGroup;
namespace Application.UserGroups.Update;

public class UpdateUserGroupHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public UpdateUserGroupHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var userGroup = await _context.UserGroups.FindAsync(new object[] { request.UserGroupId }, cancellationToken);

        if (userGroup is null || userGroup.UserGroupId != request.UserGroupId) throw NotFoundException<UserGroup>.ThrowException(request.UserGroupId);
        
        if (request.GroupCode == "Admin")
        {
            var adminGroup =
                await _context.UserGroups.FirstOrDefaultAsync(x => x.GroupCode == "Admin", cancellationToken);
            if (adminGroup is not null && adminGroup.UserGroupId != userGroup.UserGroupId) throw AdministratorsExcessException.ThrowException();
        }

        userGroup.GroupCode = request.GroupCode;
        userGroup.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return new Response(userGroup.toDto());
    }
}