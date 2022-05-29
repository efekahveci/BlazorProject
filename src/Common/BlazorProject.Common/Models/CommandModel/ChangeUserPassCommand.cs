using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Models.CommandModel;

public class ChangeUserPassCommand:IRequest<bool>
{
    public Guid UserId { get; set; }
    public string OldPass { get; set; }
    public string NewPass { get; set; }
}
