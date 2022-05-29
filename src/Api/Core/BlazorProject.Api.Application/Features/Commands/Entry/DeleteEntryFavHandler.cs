using BlazorProject.Common.Events.Entry;
using BlazorProject.Common.Queue;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.Entry;

public class DeleteEntryFavHandler : IRequestHandler<DeleteEntryFavCommand, bool>
{
    
    public async Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMesaageToExchange(RabbitMQConstans.DeleteFavExchangeName,RabbitMQConstans.ExchangeType, RabbitMQConstans.DeleteFavQueueName,new DeleteEntryFavEvent
        {
            EntryId = request.EntryId,
            UserId = request.UserId
        });

        return await Task.FromResult(true);
    }
}
