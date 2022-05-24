using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Api.Domain.Models;

namespace BlazorProject.Api.Application.Interfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetAllQuery { get; }

    IQueryable<TEntity> GetAllQueryInc(Expression<Func<TEntity, object>> includes);
    Task<TEntity> GetById(Guid id);
    Task<TEntity> GetByIdInc(Guid id, Expression<Func<TEntity, object>> includes);
    Task<bool> Create(TEntity entity);
    Task<bool> UniqueCreate(TEntity entity);

    Task<bool> Update(TEntity entity);

    Task<bool> Delete(Guid id);


}

