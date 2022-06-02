using BlazorProject.Api.Application.Features.Commands.User;
using BlazorProject.Common.Models.CommandModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand user)
    {
        var result = await _mediator.Send(user);

        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand user)
    {
        var result = await _mediator.Send(user);

        return Ok(result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand user)
    {
        var result = await _mediator.Send(user);

        return Ok(result);
    }
    [HttpPost("confirm")]
    public async Task<IActionResult> ConfirmEmail(Guid id)
    {

        var result = await _mediator.Send(new ConfirmEmailCommand { ConfirmationId = id });

        return Ok(result);

    }

    [HttpPost("changepass")]
    public async Task<IActionResult> ChangePass([FromBody] ChangeUserPassCommand changePass)
    {

        var result = await _mediator.Send(changePass);

        return Ok(result);
    }

}
