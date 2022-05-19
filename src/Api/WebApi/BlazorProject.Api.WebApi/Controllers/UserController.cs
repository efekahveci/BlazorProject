using BlazorProject.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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

    }
}
