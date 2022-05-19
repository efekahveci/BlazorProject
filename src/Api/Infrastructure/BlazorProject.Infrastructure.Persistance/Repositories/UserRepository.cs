using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Infrastructure.Persistance.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public async Task<User> GetUser(string email)
    {
        var query =  await GetAllQuery.Where(x => x.Email == email).ToListAsync();

        return query.FirstOrDefault();
    }
}
