using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HTML5.ScratchPad.DDD.Infra.Data.Repositories.Uow
{
    /// <summary>
    /// The Entity Framework implementation of IUnitOfWork
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        /// <summary>
        /// The DbContext
        /// </summary>
        public EFUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns a DbSet<TEntity> instance for access to entities of the given type in the context 
        /// and the underlying store.
        /// </summary>
        /// <typeparam name="T">An Entity of Type T</typeparam>
        /// <returns></returns>
        public IDbSet<T> Set<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
