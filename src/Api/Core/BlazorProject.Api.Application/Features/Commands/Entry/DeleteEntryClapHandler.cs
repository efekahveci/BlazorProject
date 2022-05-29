using BlazorProject.Common.Events.Entry;
using BlazorProject.Common.Queue;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.Entry;

public class DeleteEntryClapHandler : IRequestHandler<DeleteEntryClapCommand, bool>
{
    
    public async Task<bool> Handle(DeleteEntryClapCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMesaageToExchange(RabbitMQConstans.DeleteClapExchangeName,RabbitMQConstans.ExchangeType, RabbitMQConstans.DeleteClapQueueName,new DeleteEntryClapEvent
        {
            EntryId = request.EntryId,
            UserId = request.UserId
        });

        return await Task.FromResult(true);
    }
}
