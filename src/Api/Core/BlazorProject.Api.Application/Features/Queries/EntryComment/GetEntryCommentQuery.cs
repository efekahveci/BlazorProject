using BlazorProject.Common.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Queries.EntryComment;

public class GetEntryCommentQuery:IRequest<List<GetEntryCommentsView>>
{
    public Guid EntryId { get; set; }
}
