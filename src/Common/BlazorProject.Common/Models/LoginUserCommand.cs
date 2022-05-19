using BlazorProject.Common.Attributes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Models
{
    public class LoginUserCommand:IRequest<LoginUserView>
    {
        [Email]
        public string Email { get;  set; }
        [Password]
        public string Pass { get;  set; }

        public LoginUserCommand(string email,string pass)
        {
            Email = email;
            Pass = pass;
        }
    }
}
