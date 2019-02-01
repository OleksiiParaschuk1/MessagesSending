using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    public class RecepientRepository : Repository<Recepient>, IRecepientRepository
    {
        public RecepientRepository(MessagesSendingDbContext sendingDbContext) : base(sendingDbContext)
        { }

        public Recepient GetByPhoneNumber(string phoneNumber)
        {
            return _dbSet.FirstOrDefault(item => item.RecepientPhone == phoneNumber);
        }
    }
}
