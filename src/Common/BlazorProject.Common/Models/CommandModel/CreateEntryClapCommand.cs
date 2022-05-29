using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Models.CommandModel;

public class CreateEntryClapCommand : IRequest<bool>
{
    public Guid EntryId { get; set; }
    public Guid UserId { get; set; }
}

