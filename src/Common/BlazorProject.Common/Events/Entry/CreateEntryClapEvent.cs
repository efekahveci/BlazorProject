using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Events.Entry;

public class CreateEntryClapEvent
{
    public Guid EntryId { get; set; }
    public Guid UserId { get; set; }
}
