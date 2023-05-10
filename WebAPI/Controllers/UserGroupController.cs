using Application.Contracts;
using Application.Contracts.UserGroup;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserGroupController : Controller
{
    private readonly IMediator _mediator;

    public UserGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserGroupDto>> GetAsync(Guid id)
    {
        var command = new GetUserGroup.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.UserGroupDto);
    }
    
    [HttpGet]
    public async Task<ActionResult<UserGroupDto>> GetAllAsync()
    {
        var command = new GetAllUserGroups.Command();
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<UserGroupDto>> CreateAsync([FromBody] CreateUserGroupModel model)
    {
        var command = new CreateUserGroup.Command(new Guid(), model.GroupCode, model.Description);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.UserGroupDto);
    }

    [HttpPut]
    public async Task<ActionResult<UserGroupDto>> UpdateAsync([FromBody] UpdateUserGroupModel model)
    {
        var command = new UpdateUserGroup.Command(model.UserGroupId, model.UserGroupCode, model.Description);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.UserGroupDto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<UserGroupDto>> DeleteAsync(Guid id)
    {
        var command = new DeleteUserGroup.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.UserGroupDto);
    }
}