using AccountingNotebook.Data.Access.Mapping;
using AccountingNotebook.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AccountingNotebook.Data.Access.EF
{
    public class AccountNotebookContext : DbContext
    {
        public AccountNotebookContext(DbContextOptions<AccountNotebookContext> options)
        : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<AccountEntity> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AccountMap().Map(modelBuilder);
        }
    }
}
