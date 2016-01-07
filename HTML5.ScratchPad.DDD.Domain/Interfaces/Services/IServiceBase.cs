using System.Collections.Generic;

namespace HTML5.ScratchPad.DDD.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void RemoveById(int id);
        
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        void Dispose();
    }
}
