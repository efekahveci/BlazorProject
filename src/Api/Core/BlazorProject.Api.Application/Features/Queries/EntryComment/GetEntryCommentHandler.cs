using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Models.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Queries.EntryComment;

public class GetEntryCommentHandler : IRequestHandler<GetEntryCommentQuery, List<GetEntryCommentsView>>
{
    private readonly IEntryCommentRepository _repository;
    private readonly IMapper _mapper;

    public GetEntryCommentHandler(IEntryCommentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<GetEntryCommentsView>> Handle(GetEntryCommentQuery request, CancellationToken cancellationToken)
    {
        var query =  _repository.GetAllQueryInc(x=>x.Entry).Where(x => x.EntryId == request.EntryId);


       return  await query.ProjectTo<GetEntryCommentsView>(_mapper.ConfigurationProvider).ToListAsync();

    }
}
