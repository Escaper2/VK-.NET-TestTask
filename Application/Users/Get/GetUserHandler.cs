using Application.Abstractions;
using Application.Exceptions;
using Application.Mapping;
using Domain.Models;
using MediatR;
using static Application.Contracts.User.GetUser;
namespace Application.Users.Get;

public class GetUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public GetUserHandler(IDatabaseContext context)
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
        
        var userDto = user.toDto(userStateDto, userGroupDto);

        return new Response(userDto);
    }
}