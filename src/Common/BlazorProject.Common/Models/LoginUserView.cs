using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Models
{
    public class LoginUserView
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
  
        public string Token { get; set; }
    }
}
