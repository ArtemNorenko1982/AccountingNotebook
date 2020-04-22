using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingNotebook.Common;
using AccountingNotebook.Contract.DTO;

namespace AccountingNotebook.Core.Interfaces
{
    public interface IAccountService
    {
        Task<TransactionResult> DebitAccountAsync(Transaction transaction);
        Task<TransactionResult> CreditAccountAsync(Transaction transaction);
        Task<TransactionResult> BalanceAccountAsync(Account account);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    }
}
