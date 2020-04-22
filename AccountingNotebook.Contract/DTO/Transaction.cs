using System;
using AccountingNotebook.Contract.Interfaces;
using AccountingNotebook.Data;
using AccountingNotebook.Data.Entity;

namespace AccountingNotebook.Contract.DTO
{
    [DataEntity(typeof(TransactionEntity))]
    public class Transaction : IBusinessEntity, IIdentified<long>
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
        public Account Account { get; set; }
    }
}
 