using DLL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DLL.Repositories
{
    public class GenericCrudRepository<T> : IGenericCrudRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericCrudRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public  IQueryable<T> QueryAll(Expression<Func<T, bool>> expression = null)
        {
            return expression != null ? _context.Set<T>().AsQueryable().Where(expression).AsNoTracking() :
                 _context.Set<T>().AsQueryable().AsNoTracking();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression != null ? await _context.Set<T>().AsQueryable().Where(expression).AsNoTracking().ToListAsync() :
                await _context.Set<T>().AsQueryable().AsNoTracking().ToListAsync();
        }
        public async Task<T> FindSingleEntityAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public async Task CreateRangeAsync(List<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
        }

        public void Update(T entity)
        {
             _context.Set<T>().Update(entity);
        }

        public void UpdateRange(List<T> entityList)
        {
            _context.Set<T>().UpdateRange(entityList);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void DeleteRange(List<T> entityList)
        {
            _context.Set<T>().RemoveRange(entityList);
        }
        public async Task<bool> SaveCompletedAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
