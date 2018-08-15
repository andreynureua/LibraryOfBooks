using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryofBooks.DAL.Interfaces;
using LibraryofBooks.Entities;

namespace LibraryofBooks.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private LibraryContext _db;
        private DbSet<T> _dbSet;
        public Repository(LibraryContext context)
        {
            this._db = context;
            _dbSet = _db.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
           return _dbSet.AsQueryable();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
            _db.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }        
    }
}

