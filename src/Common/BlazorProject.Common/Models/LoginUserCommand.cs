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
        public string Email { get; private set; }
        public string Pass { get; private set; }

        public LoginUserCommand(string email,string pass)
        {
            Email = email;
            Pass = pass;
        }
    }
}
