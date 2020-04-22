using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingNotebook.Data.Interfaces;

namespace AccountingNotebook.Contract.Interfaces
{
    public interface IAccountingRepository<TEntity, TBusinessEntity>
        where TEntity : class, IBaseEntity
        where TBusinessEntity : class, IBusinessEntity
    { 
        #region Methods

            /// <summary>
            /// Get entity by identifier
            /// </summary>
            /// <param name="id">Identifier</param>
            /// <returns>IBusinessEntity</returns>
            Task<TBusinessEntity> GetByIdAsync(long id);

            /// <summary>
            /// Get all DB entities
            /// </summary>
            /// <returns>IENumerable{IBusinessEntity}</returns>
            Task<IReadOnlyCollection<TBusinessEntity>> GetAllAsync();

            /// <summary>
            /// Insert entity
            /// </summary>
            /// <param name="entity">Entity</param>
            Task<int> InsertAsync(TEntity entity);

            /// <summary>
            /// Insert entities
            /// </summary>
            /// <param name="entities">Entities</param>
            Task<int> InsertAsync(IEnumerable<TEntity> entities);

            /// <summary>
            /// Update entity
            /// </summary>
            /// <param name="entity">Entity</param>
            Task<int> UpdateAsync(TEntity entity);

            /// <summary>
            /// Update entities
            /// </summary>
            /// <param name="entities">Entities</param>
            Task<int> UpdateAsync(IEnumerable<TEntity> entities);

            /// <summary>
            /// Delete entity
            /// </summary>
            /// <param name="entity">Entity</param>
            Task<int> DeleteAsync(TEntity entity);

            /// <summary>
            /// Delete entities
            /// </summary>
            /// <param name="entities">Entities</param>
            Task<int> DeleteAsync(IEnumerable<TEntity> entities);

            #endregion

            #region Properties

            /// <summary>
            /// Gets a table
            /// </summary>
            IQueryable<TEntity> Table { get; }

            /// <summary>
            /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
            /// </summary>
            IQueryable<TEntity> TableNoTracking { get; }

            #endregion
        }
}
