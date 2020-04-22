using System.Collections.Generic;
using AccountingNotebook.Contract.Interfaces;
using AccountingNotebook.Data;
using AccountingNotebook.Data.Entity;

namespace AccountingNotebook.Contract.DTO
{
    [DataEntity(typeof(UserEntity))]
    public class User : IBusinessEntity, IIdentified<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
