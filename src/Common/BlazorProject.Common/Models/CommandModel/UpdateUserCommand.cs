using BlazorProject.Common.Attributes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Models.CommandModel;

public class UpdateUserCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    [Email]
    public string Email { get; set; }
    [Username]
    public string Nickname { get; set; }

}
