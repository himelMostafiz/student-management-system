using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IUnitOfWorkRepository
    {
         IDepartmentRepository DepartmentRepository { get; }
         IStudentRepository StudentRepository { get; }
         ICourseRepository CourseRepository { get; }
         ICourseStudentRepository CourseStudentRepository { get; }
         ICustomerBalanceRepository CustomerBalanceRepository { get; }
         ITransactionHistoryRepository TransactionHistoryRepository { get; }
        IStudentImageRepository StudentImageRepository { get; }
        Task<bool> SaveChangesAsync();
        Task<bool> ApplicationSaveChangesAsync();
        void Dispose();
    }
}
