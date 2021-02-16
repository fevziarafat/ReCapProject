using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.Entities;


namespace Core.DataAccess
{
    //Generic Constraint
    public interface IEntityRepositoryBase<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T,bool>>filter);
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
