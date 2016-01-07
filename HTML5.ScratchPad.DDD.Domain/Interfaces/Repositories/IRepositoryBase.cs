using System.Collections.Generic;
using System.Linq;

namespace HTML5.ScratchPad.DDD.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void DeleteById(int id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetAllLazy();
        IEnumerable<TEntity> GetAllEager();

        void Dispose();
    }
}
