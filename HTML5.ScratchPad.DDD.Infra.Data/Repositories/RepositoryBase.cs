using System;
using System.Collections.Generic;
using HTML5.ScratchPad.DDD.Infra.Data.EFContext;
using System.Linq;
using System.Data.Entity;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Repositories;

namespace HTML5.ScratchPad.DDD.Infra.Data.Repositories
{
    //N.B. DO NOT EXPOSE LINQ METHODS
    //Always use IEnumerable, SingleOrDefault, FirstOrDefault, LINQ should never leak out of the DAL
    //by returning AsQueryable(), IQueryable<TEntity> etc
    //
    //Lazy Loading
    //If you are not careful you could get 101 executed queries instead of 1 if you traverse a list of 100 items.
    //
    //http://blog.gauffin.org/2013/01/11/repository-pattern-done-right/
    //
    //Invoke ToList() before returning: ToList(), FirstOrDefault()
    //etc. So if you want to be able to keep all data related exceptions in the repositories you have to invoke those methods.
    //
    //Get is not the same as search
    //Search Methods name as Findxxx
    //Getting Entire items name as Getxxx
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProjectModelContext _context = new ProjectModelContext();

        internal DbSet<TEntity> DbSet;

        public RepositoryBase()
        {
            this.DbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// generic Get All method for Entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        /// <summary>
        /// generic Get All method for Entities
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllLazy()
        {
            return DbSet.Include("Address");
        }

        /// <summary>
        /// generic Get All method for Entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAllEager()
        {
            return DbSet.Include("Address").ToList();
        }

        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Generic Delete method for the entities by Id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            //Db.Entry(obj).State = EntityState.Deleted;
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public void Update(TEntity entityToUpdate)
        {
            //DbSet.Attach(entityToUpdate);
            /*
            N.B. The above line SHOULD NOT be used WITH EF6 OTHERWISE YOU GET Optimistic Concurrency issues
            http://stackoverflow.com/questions/30066247/updating-records-using-a-repository-pattern-with-entity-framework-6
            */
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Generic method to check if entity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
