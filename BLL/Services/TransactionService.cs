using DLL.Models;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class TransactionService : ITransactionService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public TransactionService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
    }
        public async Task FinancialTransaction()
        {
            var rand = new Random();
            var amount = rand.Next(1000);

            var transaction = new TransactionHistory() { 
                 Amount = amount
            };

            var customer = await _unitOfWork.CustomerBalanceRepository.FindSingleEntityAsync(c=>c.Email.Equals("himu@gmail.com"));

            customer.Balance += amount;

            await _unitOfWork.TransactionHistoryRepository.CreateAsync(transaction);
            //_unitOfWork.CustomerBalanceRepository.Update(customer);
            if(await _unitOfWork.SaveChangesAsync()) 
            {
                _unitOfWork.CustomerBalanceRepository.MustUpdateBalanceAsync("himu@gmail.com", amount);
            }

            //throw new NotImplementedException();
        }
    }
}
