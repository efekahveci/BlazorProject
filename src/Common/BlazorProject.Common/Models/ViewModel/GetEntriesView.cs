using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Models.ViewModel;

public class GetEntriesView
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public int Count { get; set; }
}
