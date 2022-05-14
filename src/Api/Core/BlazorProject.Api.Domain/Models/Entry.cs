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
}
