using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Api.Domain.Models;
using BlazorProject.Infrastructure.Persistance.Context;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorProject.Infrastructure.Persistance.Seed;
internal class SeedData
{
    public static IList<User> GetUsers()
    {
        var result = new Faker<User>("tr")
            .RuleFor(x=>x.Id,x=>Guid.NewGuid())
            .RuleFor(x=>x.Nickname,x=>x.Internet.UserName())
            .RuleFor(x=>x.Email,x=>x.Internet.Email())
            .RuleFor(x=>x.Pass,x=>x.Internet.Password())
            .RuleFor(x=>x.Status,x=>x.PickRandom(true,false))
            .Generate(100);

        return result;
    }

    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbcontextBuilder = new DbContextOptionsBuilder();
        dbcontextBuilder.UseNpgsql("User ID=postgres;Password=123;Server=localhost;Port=5432;Database=BlazorSocialContext;Integrated Security=true;Pooling=true;");

        var context = new BlazorSocialContext(dbcontextBuilder.Options);

        var users = GetUsers();
        var userIds = users.Select(x => x.Id);


        await context.Users.AddRangeAsync(users);

        var guids = Enumerable.Range(0,150).Select(x=>Guid.NewGuid()).ToList();

        int counter = 0;

        var entries = new Faker<Entry>("tr")
            .RuleFor(x => x.Id, x => guids[counter++])
            .RuleFor(x => x.Subject, x => x.Lorem.Sentence(5, 5))
            .RuleFor(x => x.Content, x => x.Lorem.Paragraph(2))
            .RuleFor(x => x.CreatedById, x => x.PickRandom(userIds))
            .Generate(150);

        await context.Entries.AddRangeAsync(entries);

        var comments = new Faker<EntryComment>("tr")
          .RuleFor(x => x.Id, x => Guid.NewGuid())
          .RuleFor(x => x.Content, x => x.Lorem.Paragraph(2))
          .RuleFor(x => x.CreatedById, x => x.PickRandom(userIds))
          .RuleFor(x=>x.EntryId,x=>x.PickRandom(guids))
          .Generate(1500);

        await context.EntryComments.AddRangeAsync(comments);

        await context.SaveChangesAsync();
    }



}
