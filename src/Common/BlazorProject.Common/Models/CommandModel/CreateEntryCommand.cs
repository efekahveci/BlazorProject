using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Models.CommandModel;

public class CreateEntryCommand:IRequest<Guid>
{
    public string Subject { get; set; }
    public string Content { get; set; }
    public Guid Author { get; set; }
}
