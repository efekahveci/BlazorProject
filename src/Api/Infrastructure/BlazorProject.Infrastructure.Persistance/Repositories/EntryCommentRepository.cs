using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Infrastructure.Persistance.Repositories;

public class EntryCommentRepository : GenericRepository<EntryComment>,IEntryCommentRepository
{
    
}
