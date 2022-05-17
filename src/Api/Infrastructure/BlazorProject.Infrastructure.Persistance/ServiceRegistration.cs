using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorProject.Infrastructure.Persistance;
public static class ServiceRegistration
{
    public static void AddPersistanceLayer(this IServiceCollection serviceCollection, IConfiguration configuration = null)
    {

        serviceCollection.AddDbContext<BlazorSocialContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

    }


}
