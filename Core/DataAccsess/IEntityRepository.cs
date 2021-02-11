using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.Abstract
{
    //Generic Constraint
    //class : Referans tip olabilir
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Expression filtrelemeyi sağlar linq özelliğidir.Örn= e-ticaret sitelerindeki .filter=null filtre vermeyedebilirsin demek
        List<T> GetAll(Expression<Func<T,bool>>filter=null);

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
