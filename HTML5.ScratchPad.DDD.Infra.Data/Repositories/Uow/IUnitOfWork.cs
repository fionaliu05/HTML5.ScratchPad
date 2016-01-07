using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HTML5.ScratchPad.DDD.Infra.Data.Repositories.Uow
{
    /// <summary>
    /// A unit of work, for EF, or we could call it IDataSession
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int SaveChanges();
        /// <summary>
        /// Saves all pending changes asynchronously
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state, via Task</returns>
        Task<int> SaveChangesAsync();

    }
}