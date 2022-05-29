using BlazorProject.Common.Events.Entry;
using BlazorProject.Common.Events.EntryComment;
using BlazorProject.Common.Queue;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.EntryComment;

public class CreateEntryCommentFavHandler : IRequestHandler<CreateEntryCommentFavCommand, bool>
{
     
    public async Task<bool> Handle(CreateEntryCommentFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMesaageToExchange(RabbitMQConstans.EntryCommentFavExchangeName, RabbitMQConstans.ExchangeType, RabbitMQConstans.EntryCommentFavQueueName, 
            new CreateCommentFavEvent() { EntryCommentId = request.EntryCommentId, UserId = request.UserId });

        return await Task.FromResult(true); 
    }
}
