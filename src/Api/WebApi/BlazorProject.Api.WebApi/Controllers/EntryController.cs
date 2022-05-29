using BlazorProject.Common.Models.CommandModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntryController : BaseController
{
    private readonly IMediator _mediator;

    public EntryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("createEntry")]
    public async Task<IActionResult> Post([FromBody] CreateEntryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpPost("createEntryComment")]
    public async Task<IActionResult> Post([FromBody] CreateEntryCommentCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}
