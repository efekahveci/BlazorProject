using BlazorProject.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.User
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserView>
    {
        private readonly IUserRepository _repository;
        public Task<LoginUserView> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
+