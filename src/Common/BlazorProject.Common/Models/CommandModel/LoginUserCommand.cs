using BlazorProject.Common.Attributes;
using BlazorProject.Common.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Models.CommandModel
{
    public class LoginUserCommand : IRequest<LoginUserView>
    {
        [Email]
        public string Email { get; set; }
        [Password]
        public string Pass { get; set; }


    }
}
