using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.NewFolder1
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
