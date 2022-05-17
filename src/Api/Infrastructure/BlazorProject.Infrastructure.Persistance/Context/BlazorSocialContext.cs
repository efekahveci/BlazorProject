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
    public BlazorSocialContext()
    {

    }
    public BlazorSocialContext(DbContextOptions options):base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            const string cs = "User ID=postgres;Password=123;Server=localhost;Port=5432;Database=BlazorSocialContext;Integrated Security=true;Pooling=true;";

            optionsBuilder.UseNpgsql(cs);



        }

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Entry> Entries { get; set; }
    public DbSet<EntryComment> EntryComments { get; set; }
    public DbSet<EntryClap> EntryClaps { get; set; }
    public DbSet<EntryStar> EntryStars { get; set; }
    public DbSet<EmailConfirmation> EmailConfirmations { get; set; }

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
