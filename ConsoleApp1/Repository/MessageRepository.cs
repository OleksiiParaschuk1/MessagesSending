using ConsoleApp1.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ConsoleApp1.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository, IGetSetInFile<Message>
    {
        public MessageRepository(MessagesSendingDbContext sendingDbContext) : base(sendingDbContext)
        { }

        public List<Message> GetMessagesBySenderId(int senderId)
        {
            return _dbSet.Where(item => item.SenderId == senderId).ToList();
        }

        public void SetInFileJson(Message message)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Message[]));
            Message[] messages = new Message[] { message };
            string fileName = "Message(json)" + message.MessageId.ToString() + ".json";
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, messages);
            }
        }

        public void SetInFileXml(Message message)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Message));
            string fileName = "Message(xml)" + message.MessageId.ToString() + ".xml";
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, message);

            }
        }
    }
}
