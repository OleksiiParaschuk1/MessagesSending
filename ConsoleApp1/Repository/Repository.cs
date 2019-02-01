using ConsoleApp1.NewFolder1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public void Update(TEntity entity)
        {
            _dbSet.AddOrUpdate(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
