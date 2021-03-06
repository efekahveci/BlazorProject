using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Domain.Models;

public class Entry:BaseEntity
{
    public Guid CreatedById { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public virtual User CreatedBy { get; set; }
    public virtual ICollection<EntryComment> EntryComments { get; set; }
    public virtual ICollection<EntryClap> EntryClaps { get; set; }
    public virtual ICollection<EntryStar> EntryStars { get; set; }

}
