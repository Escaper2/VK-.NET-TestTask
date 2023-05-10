using Application.Contracts.User;
using Application.Contracts.UserState;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserStateController : Controller
{
    private readonly IMediator _mediator;

    public UserStateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserStateDto>> GetAsync(Guid id)
    {
        var command = new GetUserState.Command(id);
        var response = await _mediator.Send(command, CancellationToken);
        
        return Ok(response.UserStateDto);
    }

    [HttpGet]
    public async Task<ActionResult<UserStateDto>> GetAllAsync()
    {
        var command = new GetAllUserStates.Command();
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.UserStateDto);
    }
}