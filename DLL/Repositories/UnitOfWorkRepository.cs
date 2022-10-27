using DLL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository, IDisposable
    {
        private ApplicationDbContext _context;
        private bool disposed = false;

        private IDepartmentRepository _departmentRepository;
        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;
        private ICourseStudentRepository _courseStudentRepository;
        private ICustomerBalanceRepository _customerBalanceRepository;
        private ITransactionHistoryRepository _transactionHistoryRepository;
        private IStudentImageRepository _studentImageRepositoryRepository;

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public IDepartmentRepository DepartmentRepository => _departmentRepository ??= new DepartmentRepository(_context);
        public IStudentRepository StudentRepository => _studentRepository ??= new StudentRepository(_context);
        public ICourseRepository CourseRepository => _courseRepository ??= new CourseRepository(_context); 
        public ICourseStudentRepository CourseStudentRepository => _courseStudentRepository ??= new CourseStudentRepository(_context);
        public ICustomerBalanceRepository CustomerBalanceRepository => _customerBalanceRepository ??= new CustomerBalanceRepository(_context);
        public ITransactionHistoryRepository TransactionHistoryRepository => _transactionHistoryRepository ??= new TransactionHistoryRepository(_context);
        public IStudentImageRepository StudentImageRepository => _studentImageRepositoryRepository ??= new StudentImageRepository(_context);

        public void Dispose()
        {
            Dispose( true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose( bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ApplicationSaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
