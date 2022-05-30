using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlazorProject.Common.Models.ViewModel;

public class GetEntryDetailViewModel 
{
    public Guid Id { get; set; }

    public string Subject { get; set; }
    public string Content { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedByUserName { get; set; }
}
