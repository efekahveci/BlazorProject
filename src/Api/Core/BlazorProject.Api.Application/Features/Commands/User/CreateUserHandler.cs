using AutoMapper;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Events.User;
using BlazorProject.Common.Exceptions;
using BlazorProject.Common.Models.CommandModel;
using BlazorProject.Common.Queue;
using MediatR;
using Microsoft.Extensions.Configuration;
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
    private readonly IConfiguration _conf;

    public CreateUserHandler(IMapper mapper, IUserRepository repository,IConfiguration configuration)
    {
        _conf = configuration;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUser(request.Email);

        if (user is not null)
            throw new DbValidEx("User already exist");

        var dbUser = _mapper.Map<Domain.Models.User>(request);

        if(await _repository.Create(dbUser))
        {

            var @event = new EmailChangeEvent()
            {
                OldEmail = null,
                NewEmail = dbUser.Email
            };

            QueueFactory.SendMesaageToExchange(RabbitMQConstans.UserExchangeName,RabbitMQConstans.ExchangeType, RabbitMQConstans.UserEmailChangeQueueName, @event);

        }

        return dbUser.Id;
    }
}
