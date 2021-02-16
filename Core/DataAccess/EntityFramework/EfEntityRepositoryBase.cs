using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepositoryBase<TEntity>
       where TEntity:class,IEntity,new()
       where TContext:DbContext,new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                if (filter == null)
                    return context.Set<TEntity>().ToList();
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedData = context.Entry(entity);
                updatedData.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedData = context.Entry(entity);
                deletedData.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
