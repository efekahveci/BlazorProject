using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorProject.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    //JWT Gönderilmez ise
    public Guid UserId
    {
        get
        {
            return new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
