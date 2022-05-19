using AutoMapper;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Exceptions;
using BlazorProject.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UpdateUserHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _repository.GetById(request.Id);

            if (dbUser is null)
                throw new DbValidEx("User not found");

            _mapper.Map(request, dbUser);

            var result = _repository.Update(dbUser);

            return dbUser.Id;
        }
    }
}
