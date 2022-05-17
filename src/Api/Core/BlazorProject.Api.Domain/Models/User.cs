using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Domain.Models;
public class User:BaseEntity
{
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string Pass { get; set; }

    public virtual ICollection<Entry> Entries{ get; set; }
    public virtual ICollection<EntryComment> EntryComments { get; set; }
    public virtual ICollection<EntryStar> EntryStars { get; set; }
}
