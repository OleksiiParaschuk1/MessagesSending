using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.NewFolder1
{
    public interface IGetSetInFile<TEntity>
    {
        void SetInFileJson(string FileName);
        void GetFromFileJson(string FileName);
        //void Update();
        //void Delete(int Id);
        //void Delete(TEntity entity);
        //void SaveChanges();
    }
}
