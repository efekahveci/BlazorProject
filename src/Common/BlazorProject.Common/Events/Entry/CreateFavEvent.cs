using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Events.Entry;

public class CreateFavEvent
{
    public Guid UserId { get; set; }
    public Guid EntryId { get; set; }
}
