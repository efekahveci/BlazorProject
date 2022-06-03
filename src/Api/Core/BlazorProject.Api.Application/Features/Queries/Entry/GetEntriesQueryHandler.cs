using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Models.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Api.Application.Features.Queries.Entry;

public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, List<GetEntriesView>>
{
    private readonly IEntryRepository _entryRepo;
    private readonly IMapper _mapper;

    public GetEntriesQueryHandler(IEntryRepository entryRepo, IMapper mapper)
    {
        _entryRepo = entryRepo;
        _mapper = mapper;
    }

    public async Task<List<GetEntriesView>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = _entryRepo.GetAllQuery;

        if (request.Today)
            query = query.Where(x => x.CreatedDate.Date == DateTime.Now.Date);

        query = _entryRepo.GetAllQueryInc(x => x.EntryComments).OrderBy(x => x.CreatedDate).Take(request.Count);

        return await query.ProjectTo<GetEntriesView>(_mapper.ConfigurationProvider).ToListAsync();

    }
}
