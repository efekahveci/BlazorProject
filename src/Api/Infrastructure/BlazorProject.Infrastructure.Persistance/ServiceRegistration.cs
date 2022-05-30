using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Infrastructure.Persistance.Context;
using BlazorProject.Infrastructure.Persistance.ContextEngine;
using BlazorProject.Infrastructure.Persistance.Repositories;
using BlazorProject.Infrastructure.Persistance.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorProject.Infrastructure.Persistance;
public static class ServiceRegistration
{
    public static IServiceCollection AddPersistanceLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        serviceCollection.AddSingleton<IEngine, BlazorSocialContextEngine>();
        //serviceCollection.AddScoped<IUserRepository, UserRepository>();
        //serviceCollection.AddScoped<IEntryRepository, EntryRepository>();

        var classes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.BaseType != null
        && type.BaseType.IsGenericType
        && type.BaseType.GetGenericTypeDefinition() == (typeof(GenericRepository<>))).ToList();

        foreach (var item in classes)
        {
            var interfaceType = item.GetInterfaces().Where(x => x == (typeof(IGenericRepository<>))).ToList();
            if (interfaceType != null)
            {
                serviceCollection.AddScoped(interfaceType.First(), item);
            }   
            //   serviceCollection.AddScoped( item);
        }

        serviceCollection.AddDbContext<BlazorSocialContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


        var seed = new SeedData();

        seed.SeedAsync(configuration).GetAwaiter().GetResult();


        return serviceCollection;
    }



    public static void ConfigureRequestPipeline(this IApplicationBuilder application)
    {
        EngineContext.Current.ConfigureRequestPipeline(application);
    }

}
