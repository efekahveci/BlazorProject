using BlazorProject.Common.Events.Entry;
using BlazorProject.Common.Models.CommandModel;
using BlazorProject.Common.Queue;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.EntryClap;

public class CreateEntryClapHandler : IRequestHandler<CreateEntryClapCommand, bool>
{
    public async Task<bool> Handle(CreateEntryClapCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMesaageToExchange(RabbitMQConstans.ClapExchangeName, RabbitMQConstans.ExchangeType, RabbitMQConstans.ClapQueueName,
            new CreateEntryClapEvent() { EntryId = request.EntryId, UserId = request.UserId });

        return await Task.FromResult(true);
    }
}
