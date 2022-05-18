using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection serviceCollection)
    {

        var assm = Assembly.GetExecutingAssembly();

        serviceCollection.AddMediatR(assm);
        serviceCollection.AddAutoMapper(assm);

        return serviceCollection;
    }





}

