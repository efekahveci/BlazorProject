using BlazorProject.Common.Models.ViewModel;
using MediatR;

namespace BlazorProject.Api.Application.Features.Queries.Entry;

public class GetEntriesQuery : IRequest<List<GetEntriesView>>
{
    public bool Today { get; set; }
    public int Count { get; set; } = 100;

}
