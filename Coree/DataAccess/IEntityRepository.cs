using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Coree.DataAccess
{
    //generic constraint 
    // class:referans tip
    //IEntityy : Intity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmalı. (IEntitiy newlenemez çünkü interface)

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
