using AutoMapper;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Events.User;
using BlazorProject.Common.Exceptions;
using BlazorProject.Common.Models;
using BlazorProject.Common.Queue;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.User;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _repository;
    private readonly IConfiguration _conf;

    public UpdateUserHandler(IMapper mapper, IUserRepository repository, IConfiguration configuration)
    {
        _conf = configuration;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await _repository.GetById(request.Id);

        if (dbUser is null)
            throw new DbValidEx("User not found");

        _mapper.Map(request, dbUser);

        //Buraya bi merge fonk gerekebilir.

        if (await _repository.Update(dbUser) && string.CompareOrdinal(dbUser.Email, request.Email) !=0)
        {

            var @event = new EmailChangeEvent()
            {
                OldEmail = null,
                NewEmail = dbUser.Email
            };

            QueueFactory.SendMesaageToExchange(_conf["RabbitMQ:UserExchangeName"], _conf["RabbitMQ:ExchangeType"], _conf["RabbitMQ:UserEmailChangeQueueName"], @event);

            dbUser.Status = false;
            await _repository.Update(dbUser);
        }

        return dbUser.Id;
    }
}
