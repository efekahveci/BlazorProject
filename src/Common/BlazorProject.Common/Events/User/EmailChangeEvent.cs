using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Events.User
{
    public class EmailChangeEvent
    {
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
    }
}
