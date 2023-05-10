using Application.Abstractions;
using Application.Exceptions;
using Application.Mapping;
using Domain.Models;
using MediatR;
using static Application.Contracts.User.DeleteUser;
namespace Application.Users.Delete;

public class DeleteUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public DeleteUserHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(new object[] { request.UserId }, cancellationToken);
        
        if (user is null || user.UserId != request.UserId) throw NotFoundException<User>.ThrowException(request.UserId);

        var userState = await _context.UserStates.FindAsync(new object[] { user.UserStateId }, cancellationToken);
        var userGroup = await _context.UserGroups.FindAsync(new object[] { user.UserGroupId }, cancellationToken);
    
        var userStateDto = userState!.toDto();
        var userGroupDto = userGroup!.toDto();
        
        userState!.StateCode = "Blocked";

        await _context.SaveChangesAsync(cancellationToken);

        return new Response(user.toDto(userStateDto, userGroupDto));
    }
}