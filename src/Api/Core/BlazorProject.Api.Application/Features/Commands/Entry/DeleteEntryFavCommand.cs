using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.Entry;

public class DeleteEntryFavCommand:IRequest<bool>
{
    public Guid EntryId { get; set; }
    public Guid UserId { get; set; }
}
