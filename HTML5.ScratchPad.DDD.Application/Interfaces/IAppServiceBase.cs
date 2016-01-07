using System.Collections.Generic;

namespace HTML5.ScratchPad.DDD.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        void Dispose();
    }
}
