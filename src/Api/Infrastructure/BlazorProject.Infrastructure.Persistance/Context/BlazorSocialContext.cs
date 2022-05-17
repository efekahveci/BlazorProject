using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Infrastructure.Persistance.Context;

public class BlazorSocialContext:DbContext
{
    public BlazorSocialContext(DbContextOptions options):base(options)
    {

    }

    public User Users { get; set; }
    public Entry Entries { get; set; }
    public EntryComment EntryComments { get; set; }
    public EntryClap EntryClaps { get; set; }
    public EntryStar EntryStars { get; set; }
    public EmailConfirmation EmailConfirmations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();      
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);    
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);     
    }


    private void OnBeforeSave()
    {
        var entity = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added)
            .Select(x => (BaseEntity)x.Entity).ToList();

        entity.ForEach(i => i.CreatedDate=DateTime.UtcNow);
    }
}
