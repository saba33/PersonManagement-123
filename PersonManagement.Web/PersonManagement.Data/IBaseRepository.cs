using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonManagement.Data
{
    public interface IBaseRepository<T> where T : class
    {
        #region Methods 

        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(params object[] key);

        Task AddAsync(T entity);

        Task RemoveAsync(T entity);

        Task RemoveAsync(params object[] Key);

        Task UpdateAsync(T entity);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        #endregion

        #region Sets

        IQueryable<T> Table { get; }

        #endregion
    }
}
