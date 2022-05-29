using BlazorProject.Common.Events.Entry;
using BlazorProject.Common.Events.EntryComment;
using BlazorProject.Common.Queue;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.Entry;

public class CreateEntryFavHandler : IRequestHandler<CreateEntryFavCommand, bool>
{
 
    
    public async Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMesaageToExchange(RabbitMQConstans.EntryFavExchangeName, RabbitMQConstans.ExchangeType, RabbitMQConstans.EntryFavQueueName, 
            new CreateFavEvent() { EntryId = request.EntryId, UserId = request.UserId });

        return await Task.FromResult(true); 
    }
}
