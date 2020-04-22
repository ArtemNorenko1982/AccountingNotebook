using Microsoft.EntityFrameworkCore;

namespace AccountingNotebook.Data.Access.EF
{
    public interface IDBEntityMapper
    {
        void Map(ModelBuilder modelBuilder);
    }
}
