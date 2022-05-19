using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Api.Domain.Models;

namespace BlazorProject.Api.Application.Interfaces.Repositories;
public interface IUserRepository:IGenericRepository<User>
{
   Task<User> GetUser(string email);

}
