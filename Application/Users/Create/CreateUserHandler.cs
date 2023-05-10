using Application.Abstractions;
using Application.Contracts;
using Application.Exceptions;
using Application.Mapping;
using Domain.Models;
using MediatR;
using static Application.Contracts.User.CreateUser;
namespace Application.Users.Create;

public class CreateUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateUserHandler(IDatabaseContext context)
    {
        _context = context;
    }

    private static readonly List<string> UsersInProcess = new List<string>();
    
    
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        if (UsersInProcess.Contains(request.Login))
        {
            throw CommandAlreadyRunningException.ThrowException(request.Login);
        }
        
        UsersInProcess.Add(request.Login);

        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        
        var userGroup = await _context.UserGroups.FindAsync(new object[] { request.UserGroupId }, cancellationToken);
        if (userGroup is null || userGroup.UserGroupId != request.UserGroupId) throw NotFoundException<UserGroup>.ThrowException(request.UserGroupId);
        
        var user = new User()
        {
            UserId = request.UserId,
            Login = request.Login,
            Password = request.Password,
            CreatedDate = request.CreatedDate,
            UserGroupId = request.UserGroupId,
            UserStateId = request.UserStateId,
            Name = request.Name
        };
        
        var userState = new UserState()
        {
            UserStateId = request.UserStateId,
            StateCode = request.StateCode,
            Description = request.StateDescription
        };
        var userStateDto = userState.toDto();
        var userGroupDto = userGroup.toDto();
        
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        UsersInProcess.Remove(request.Login);

        return new Response(user.toDto(userStateDto, userGroupDto));
    }
}