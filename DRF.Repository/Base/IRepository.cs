using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Repository.Base
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWithPagging(int pageIndex, int pageSize);
        T GetById(int id);
        void DeleteById(int id);
        void DeleteRangeByIds(IEnumerable<int> ids);
        void DeleteByItem(T entity);
        void DeleteRangeByItems(IEnumerable<T> entities);
        void DeleteFromDatabaseById(int id);
        void DeleteFromDatabaseByItem(T entity);
        void DeleteRangeFromDatabaseByIds(IEnumerable<int> ids);
        void DeleteRangeFromDatabaseByItems(IEnumerable<T> entities);
    }
}
