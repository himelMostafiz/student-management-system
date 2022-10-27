using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface ICustomerBalanceRepository : IGenericCrudRepository<CustomerBalance>
    {
        Task MustUpdateBalanceAsync(string email, decimal amount);
    }
}
