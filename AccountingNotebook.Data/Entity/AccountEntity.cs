using System;
using System.Collections.Generic;
using AccountingNotebook.Data.Interfaces;

namespace AccountingNotebook.Data.Entity
{
    public class AccountEntity : IBaseEntity
    {
        public long Id { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime OperationDate { get; set; }
        public long UserId { get; set; }
        public UserEntity User { get; set; }
        public IEnumerable<TransactionEntity> Transactions { get; set; }
    }
}
