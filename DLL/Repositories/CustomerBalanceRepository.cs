using DLL.DBContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class CustomerBalanceRepository : GenericCrudRepository<CustomerBalance>,ICustomerBalanceRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerBalanceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task MustUpdateBalanceAsync(string email, decimal amount)
        {
            var customerBalance = await _context.CustomerBalances.FirstOrDefaultAsync(c => c.Email == email);
            customerBalance.Balance += amount;
            bool isUpdated = false;

            do
            {
                try
                {
                    if(await _context.SaveChangesAsync() > 0)
                    {
                        isUpdated = true;
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is CustomerBalance)
                        {
                            var databaseEntry = entry.GetDatabaseValues();
                            var databaseValue = (CustomerBalance)databaseEntry.ToObject();
                            databaseValue.Balance += amount;
                            entry.OriginalValues.SetValues((databaseEntry));
                            entry.CurrentValues.SetValues((databaseValue));
                        }
                    }

                }

            } while (!isUpdated);

            
        }
    }
}
