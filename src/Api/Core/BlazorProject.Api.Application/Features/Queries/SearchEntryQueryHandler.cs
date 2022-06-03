using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Models.QueryModel;
using BlazorProject.Common.Models.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Queries;

public class SearchEntryQueryHandler : IRequestHandler<SearchEntryQuery, List<SearchEntryViewModel>>
{
    private readonly IEntryRepository _entryRepository;

    public SearchEntryQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task<List<SearchEntryViewModel>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
    {
        // TODO validation, request.SearchText length should be checked

        var result = _entryRepository
            .GetAllQueryInc(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%"))
            .Select(i => new SearchEntryViewModel()
            {
                Id = i.Id,
                Subject = i.Subject,
            });

        return await result.ToListAsync(cancellationToken);
    }
}

