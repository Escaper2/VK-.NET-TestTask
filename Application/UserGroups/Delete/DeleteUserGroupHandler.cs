using Application.Abstractions;
using Application.Exceptions;
using Application.Mapping;
using Domain.Models;
using MediatR;
using static Application.Contracts.UserGroup.DeleteUserGroup;
namespace Application.UserGroups.Delete;

public class DeleteUserGroupHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public DeleteUserGroupHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var userGroup = await _context.UserGroups.FindAsync(new object[] { request.UserGroupId }, cancellationToken);

        if (userGroup is null || userGroup.UserGroupId != request.UserGroupId) throw NotFoundException<UserGroup>.ThrowException(request.UserGroupId);

        _context.UserGroups.Remove(userGroup);

        await _context.SaveChangesAsync(cancellationToken);

        return new Response(userGroup.toDto());
    }
}