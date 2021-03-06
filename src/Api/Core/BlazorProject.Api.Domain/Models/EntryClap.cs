using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Domain.Models;
public class EntryClap:BaseEntity
{
    public Guid EntryId { get; set; }     
    public Guid CreatedById { get; set; }     
    public int Clap { get; set; }
    public virtual Entry Entry { get; set; }
}
