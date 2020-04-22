using System;
using System.Collections.Generic;
using AccountingNotebook.Contract.DTO;


namespace AccountingNotebook.Common
{
    public class TransactionResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorDescription { get; set; }
        public decimal MoneyAmountToWithdraw { get; set; }
        public decimal MoneyAmountToPut { get; set; }
        public decimal MoneyAmount { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
