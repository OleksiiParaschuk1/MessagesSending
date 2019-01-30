using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MessagesSendingDbContext db = new MessagesSendingDbContext();
            User user = new User();
            user.UserId = "1";
            db.Users.Add(user);
            db.SaveChanges();


        }
    }
}
