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

namespace BlazorProject.Api.Application.Features.Commands.User;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _repository;

    public CreateUserHandler(IMapper mapper, IUserRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUser(request.Email);

        if (user is not null)
            throw new DbValidEx("User already exist");

        var dbUser = _mapper.Map<Domain.Models.User>(request);

        await  _repository.Create(dbUser);

        return dbUser.Id;
    }
}
