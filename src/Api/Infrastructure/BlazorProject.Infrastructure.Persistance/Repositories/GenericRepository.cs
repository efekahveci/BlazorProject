using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Api.Domain.Models;
using BlazorProject.Infrastructure.Persistance.Context;
using BlazorProject.Infrastructure.Persistance.ContextEngine;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Infrastructure.Persistance.Repositories;
public  class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly BlazorSocialContext _context;

    public  GenericRepository()
    {
        _context = EngineContext.Current.Resolve<BlazorSocialContext>();
    }

    public virtual  DbSet<TEntity> Table => _context.Set<TEntity>();



    public virtual  IQueryable<TEntity> GetAllQuery => Table.AsNoTracking().AsQueryable();


    public virtual  async Task<bool> Create(TEntity entity)
    {
         await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public virtual  async Task<bool> Delete(Guid id)
    {

        var entity = Table.Find();
        entity.Status = false;
        Table.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }



    public virtual  IQueryable<TEntity> GetAllQueryInc(Expression<Func<TEntity, object>> includes)
    {
        return Table.Include(includes).AsNoTracking().AsQueryable();
    }


    public virtual  async Task<TEntity> GetById(Guid id)
    {
        var result = await Table.FindAsync(id);

        if (result.Status != true)
            return null;
        else return result;
    }
    public virtual  async Task<TEntity> GetByIdInc(Guid id, Expression<Func<TEntity, object>> includes)
    {
        return await Table
                     .AsNoTracking()
                     .Include(includes)
                     .Where(x => x.Status == true)
                     .FirstOrDefaultAsync(e => e.Id == id);
    }



    public virtual  async Task<bool> UniqueCreate(TEntity entity)
    {
        var result = await Table.AsNoTracking().FirstOrDefaultAsync(e => e.Id == entity.Id);

        if (result != null)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public virtual  async Task<bool> Update(TEntity entity)
    {

        Table.Update(entity);

        await _context.SaveChangesAsync();
        return true;





    }
}
