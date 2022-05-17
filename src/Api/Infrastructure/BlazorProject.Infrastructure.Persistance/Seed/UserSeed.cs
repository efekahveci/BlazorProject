using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Api.Domain.Models;
using Bogus;

namespace BlazorProject.Infrastructure.Persistance.Seed;
internal class UserSeed
{
    public static IList<User> GetUser()
    {
        var result = new Faker<User>("tr")
            .RuleFor(x=>x.Id,Guid.NewGuid())
            .RuleFor(x=>x.Nickname,x=>x.Internet.UserName())
            .RuleFor(x=>x.Email,x=>x.Internet.Email())
            .RuleFor(x=>x.Pass,x=>x.Internet.Password())
            .RuleFor(x=>x.Status,x=>x.PickRandom(true,false))
            .Generate(100);

        return result;
    }
}
