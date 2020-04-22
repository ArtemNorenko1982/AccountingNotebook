using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingNotebook.Common;
using AccountingNotebook.Contract.DTO;
using AccountingNotebook.Contract.Interfaces;
using AccountingNotebook.Core.Interfaces;
using AccountingNotebook.Data.Entity;

namespace AccountingNotebook.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountingRepository<AccountEntity, Account> _repository;

        public AccountService(IAccountingRepository<AccountEntity, Account> repository)
        {
            this._repository = repository;
        }

        public async Task<TransactionResult> DebitAccountAsync(Transaction transaction)
        {
            var result = new TransactionResult();
            
            return result;
        }

        public async Task<TransactionResult> CreditAccountAsync(Transaction transaction)
        {
            var result = new TransactionResult();

            return result;
        }

        public async Task<TransactionResult> BalanceAccountAsync(Account account)
        {
            var result = new TransactionResult();

            return result;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            var result = await _repository.GetAllAsync();
            var transactions = result.ToList().FirstOrDefault()?.Transactions;
            return transactions;
        }
    }
}
