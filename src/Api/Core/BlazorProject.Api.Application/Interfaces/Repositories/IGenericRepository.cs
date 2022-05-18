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
    Task Create(TEntity entity);
    Task UniqueCreate(TEntity entity);

    Task Update(TEntity entity);

    Task Delete(Guid id);


}

