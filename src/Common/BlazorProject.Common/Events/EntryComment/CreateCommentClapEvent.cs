using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Events.EntryComment;

public class CreateCommentClapEvent
{
    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }
}
