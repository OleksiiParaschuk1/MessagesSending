using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MessagesSendingDbContext sendingDbContext) : base(sendingDbContext)
        { }

        public User GetByPhoneNumber(string phoneNumber)
        {
            return _dbSet.FirstOrDefault(item => item.UserPhone == phoneNumber);
        }
    }
}
