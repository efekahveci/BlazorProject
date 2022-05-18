using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Api.Domain.Models;

namespace BlazorProject.Infrastructure.Persistance.Repositories;
internal class UserRepository : GenericRepository<User>, IUserRepository
{
    
}
