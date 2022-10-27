using DLL.DBContext;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repositories
{
    public class TransactionHistoryRepository : GenericCrudRepository<TransactionHistory>, ITransactionHistoryRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionHistoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
