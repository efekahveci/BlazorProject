using BlazorProject.Common.Attributes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Models;

public class CreateUserCommand:IRequest<Guid>
{
    [Email]
    public string Email { get; set; }
    [Username]
    public string Nickname { get; set; }
    [Password]
    public string Pass { get; set; }
}
