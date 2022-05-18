using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Infrastructure.Persistance.Context;
using BlazorProject.Infrastructure.Persistance.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorProject.Infrastructure.Persistance;
public static class ServiceRegistration
{
    public static IServiceCollection AddPersistanceLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {

        serviceCollection.AddDbContext<BlazorSocialContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


        var seed = new SeedData();

        seed.SeedAsync(configuration).GetAwaiter().GetResult();

        return serviceCollection;
    }



  

}
