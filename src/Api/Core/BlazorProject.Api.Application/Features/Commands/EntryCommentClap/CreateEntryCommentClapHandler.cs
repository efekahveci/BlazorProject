using BlazorProject.Common.Events.EntryComment;
using BlazorProject.Common.Models.CommandModel;
using BlazorProject.Common.Queue;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.EntryCommentClap;

public class CreateEntryCommentClapHandler : IRequestHandler<CreateEntryCommentClapCommand, bool>
{
    public async Task<bool> Handle(CreateEntryCommentClapCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMesaageToExchange(RabbitMQConstans.CommentClapExchangeName, RabbitMQConstans.ExchangeType, RabbitMQConstans.CommentClapExchangeName,
            new CreateCommentClapEvent() { EntryCommentId = request.EntryCommentId, UserId = request.UserId });

        return await Task.FromResult(true);
    }

    
}
