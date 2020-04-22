using AccountingNotebook.Data.Access.EF;
using AccountingNotebook.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AccountingNotebook.Data.Access.Mapping
{
    public class AccountMap : IDBEntityMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>(entity =>
            {
                entity.HasOne(account => account.User)
                    .WithMany(user => user.Accounts)
                    .HasForeignKey(account => account.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(account => account.Transactions)
                    .WithOne(transaction => transaction.Account)
                    .HasForeignKey(account => account.AccountId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(account => account.User)
                    .WithMany(user => user.Accounts)
                    .HasForeignKey(account => account.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
