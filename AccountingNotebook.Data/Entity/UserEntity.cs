using System.Collections.Generic;
using AccountingNotebook.Data.Interfaces;

namespace AccountingNotebook.Data.Entity
{
    public class UserEntity : IBaseEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<AccountEntity> Accounts { get; set; }
    }
}
