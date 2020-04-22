using System;
using System.Collections.Generic;
using AccountingNotebook.Contract.Interfaces;
using AccountingNotebook.Data;
using AccountingNotebook.Data.Entity;

namespace AccountingNotebook.Contract.DTO
{
    [DataEntity(typeof(AccountEntity))]
    public class Account : IBusinessEntity, IIdentified<long>
    {
        public long Id { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime OperationDate { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
