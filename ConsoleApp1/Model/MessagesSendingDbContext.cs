using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1
{
    public class MessagesSendingDbContext: DbContext
    {
        public MessagesSendingDbContext() : base("MessagesSendingDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<RecepientMessage> RecepientMessages { get; set; }
        public DbSet<Recepient> Recepients { get; set; }
    }
}
