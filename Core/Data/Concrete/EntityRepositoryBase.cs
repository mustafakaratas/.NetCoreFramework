using Core.Data.Abstract;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Data.Concrete
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter != null
                    ? context.Set<TEntity>().Where(filter).ToList()
                    : context.Set<TEntity>().ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
