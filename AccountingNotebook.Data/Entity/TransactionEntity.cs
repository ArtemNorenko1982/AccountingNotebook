using System;
using AccountingNotebook.Data.Interfaces;

namespace AccountingNotebook.Data.Entity
{
    public class TransactionEntity : IBaseEntity
    {
        public long Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionSum { get; set; }
        /// <summary>
        /// -1 Credit, 1 - Debit
        /// </summary>
        public int Operation { get; set; }
        public bool IsSuccess { get; set; }
        public string RefuseReason { get; set; }
        public long AccountId { get; set; }
        public AccountEntity Account { get; set; }
    }
}
