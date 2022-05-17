using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Domain.Models;
public class EntryComment:BaseEntity
{
    public Guid EntryId { get; set; }
    public Guid CreatedById { get; set; }

    public string Content { get; set; }

    public virtual Entry Entry { get; set; }
    public virtual User CreatedBy { get; set; }
    public virtual ICollection<EntryClap> EntryClaps { get; set; }
    public virtual ICollection<EntryStar> EntryStars { get; set; }
}
