using BlazorProject.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Interfaces.Repositories;

public interface IEmailConfirmRepository : IGenericRepository<EmailConfirmation>
{
    
}
