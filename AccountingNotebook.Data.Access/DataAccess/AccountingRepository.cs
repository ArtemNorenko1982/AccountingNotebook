using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingNotebook.Contract.Interfaces;
using AccountingNotebook.Data.Access.EF;
using AccountingNotebook.Data.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountingNotebook.Data.Access.DataAccess
{
    public class AccountingRepository<TEntity, TBusinessEntity> : IAccountingRepository<TEntity, TBusinessEntity>
        where TEntity : class, IBaseEntity
        where TBusinessEntity : class, IBusinessEntity
    {

        private DbSet<TEntity> _entities;

        public AccountingRepository(AccountNotebookContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        protected AccountNotebookContext Context { get; }
        protected IMapper Mapper { get; }

        public async Task<TBusinessEntity> GetByIdAsync(long id)
        {
            return Mapper.Map<TBusinessEntity>(await Entities.FindAsync(id));
        }

        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (Context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }

            try
            {
                Context.SaveChanges();
                return exception.ToString();
            }
            catch (Exception ex)
            {
                //if after the rollback of changes the context is still not saving,
                //return the full text of the exception that occurred when saving
                return ex.ToString();
            }
        }

        public async Task<IReadOnlyCollection<TBusinessEntity>> GetAllAsync()
        {
            var attributes = typeof(TBusinessEntity).GetCustomAttributes(typeof(DataEntityAttribute), false);
            if (!attributes.Any())
            {
                throw new NotImplementedException(
                    $"Implement attribute to type {typeof(TBusinessEntity).Name}");
            }

            var dataEntityType = ((DataEntityAttribute)attributes.First()).DataEntityType;

            var methodGetAll = Context.GetType().GetMethod("Set").MakeGenericMethod(dataEntityType);
            var entities = await Task.Factory.StartNew(() => (IEnumerable<TEntity>)methodGetAll.Invoke(Context, null));

            var result = Mapper.Map<IReadOnlyCollection<TBusinessEntity>>(entities);
            return result;
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                await Entities.AddAsync(entity);
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                //TODO: add logging
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
                return 0;
            }
        }

        public async Task<int> InsertAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                await Entities.AddRangeAsync(entities);
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                //TODO: add logging
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
                return 0;
            }
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Update(entity);
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public async Task<int> UpdateAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.UpdateRange(entities);
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Remove(entity);
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public async Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.RemoveRange(entities);
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = Context.Set<TEntity>();

                return _entities;
            }
        }
    }
}
