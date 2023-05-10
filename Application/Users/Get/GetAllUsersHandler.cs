using Application.Abstractions;
using Application.Dto;
using Application.Mapping;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.User.GetAllUsers;
namespace Application.Users.Get;

public class GetAllUsersHandler : IRequestHandler<Command, Response>
{
    private readonly  IDatabaseContext _context;

    public GetAllUsersHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var users = await _context.Users.ToListAsync(cancellationToken);
        var userStates = await _context.UserStates.ToListAsync(cancellationToken);
        var userGroups = await _context.UserGroups.ToListAsync(cancellationToken);

        var result = await Task.WhenAll(users.Select(async x =>
        {
            var userState = userStates.FirstOrDefault(us => us.UserStateId == x.UserStateId);
            var userGroup = userGroups.FirstOrDefault(ug => ug.UserGroupId== x.UserGroupId);
            var stateDto = userState!.toDto();
            var groupDto = userGroup!.toDto();
            var dto = x.toDto(stateDto, groupDto);
            return dto;
        }));
        
        return new Response(result.ToList());
    }
}