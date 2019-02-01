using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    public class RecepientMessageRepository : Repository<RecepientMessage>, IRecepientMessageRepository
    {
        public RecepientMessageRepository(MessagesSendingDbContext sendingDbContext) : base(sendingDbContext)
        { }

        public List<RecepientMessage> GetRecepientsMessagesByMessageId(int messageId)
        {
            return _dbSet.Where(item => item.MessageId == messageId).ToList();
        }
        public List<RecepientMessage> GetRecepientsMessagesByRecipientId(int recipientId)
        {
            return _dbSet.Where(item => item.MessageId == recipientId).ToList();
        }
    }
}
