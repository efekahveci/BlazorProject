using AutoMapper;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Models.CommandModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.Entry;

public class CreateEntryHandler : IRequestHandler<CreateEntryCommand, Guid>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IMapper _mapper;
    public CreateEntryHandler(IEntryRepository repository, IMapper mapper)
    {
        _entryRepository = repository;
        _mapper = mapper;
    }
   
    public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
    {
        var dbEntry = _mapper.Map<Domain.Models.Entry>(request);

        await _entryRepository.Create(dbEntry);

        return dbEntry.Id;

    }
}
