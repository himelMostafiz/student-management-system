using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IGenericCrudRepository<T> where T : class
    {
        IQueryable<T> QueryAll(Expression <Func<T,bool>> expression = null);
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> expression = null);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(List<T> entity);
        void Update(T entity);
        void UpdateRange(List<T> entityList);
        void Delete(T entity);
        void DeleteRange(List<T> entityList);
        Task<T> FindSingleEntityAsync(Expression<Func<T,bool>> expression);
        Task<bool> SaveCompletedAsync();
    }
}
