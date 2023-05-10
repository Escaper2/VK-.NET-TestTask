using Application.Contracts.User;
using Application.Contracts.UserGroup;
using Application.Contracts.UserState;
using Application.Dto;
using Application.Users.Get;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> GetAsync(Guid id)
    {
        var command = new GetUser.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<UserDto>> GetAllAsync()
    {
        var command = new GetAllUsers.Command();
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateAsync(CreateUserModel model)
    {
        var userStateId = Guid.NewGuid();
        
        var userCommand = new CreateUser.Command(new Guid(), model.Login, model.Password, DateOnly.FromDateTime(DateTime.Now), model.UserGroupId,
            userStateId, model.Name, "Active", model.UserStateDescription);
        var userStateCommand = new CreateUserState.Command(userStateId, "Active", model.UserStateDescription);
        var userGroupCommand = new GetUserGroup.Command(model.UserGroupId);
        
        var userResponse = await _mediator.Send(userCommand, CancellationToken);
        var userStateResponse = await _mediator.Send(userStateCommand, CancellationToken);
        var userGroupResponse = await _mediator.Send(userGroupCommand, CancellationToken);
        
        userResponse.User.UserStateDto = userStateResponse.UserStateDto;
        userResponse.User.UserGroupDto = userGroupResponse.UserGroupDto;

        return Ok(userResponse);
    }

    [HttpPut]
    public async Task<ActionResult<UserDto>> UpdateAsync(UpdateUserModel model)
    {
        var command = new UpdateUser.Command(model.UserId, model.Login, model.Password, model.Name);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<UserDto>> DeleteAsync(Guid id)
    {
        var command = new DeleteUser.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }
}