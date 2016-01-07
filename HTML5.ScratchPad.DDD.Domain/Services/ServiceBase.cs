using System;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Repositories;

namespace HTML5.ScratchPad.DDD.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> respository)
        {
            _repository = respository;
        }

        public void Add(TEntity obj)
        {
            _repository.Insert(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public void RemoveById(int id)
        {
            _repository.DeleteById(id);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
