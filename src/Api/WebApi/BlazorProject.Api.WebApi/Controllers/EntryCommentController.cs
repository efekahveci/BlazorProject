using BlazorProject.Api.Application.Features.Queries.EntryComment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryCommentController : BaseController
    {
        private readonly IMediator _mediator;

        public EntryCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getEntryCommentsById")]
        public async Task<IActionResult> GetAllComments([FromQuery] GetEntryCommentQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
