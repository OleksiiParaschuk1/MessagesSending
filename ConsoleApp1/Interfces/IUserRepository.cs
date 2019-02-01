using ConsoleApp1.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByPhoneNumber(string phoneNumber);
    }
}
