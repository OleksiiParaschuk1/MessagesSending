using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [DataContract]
    [Serializable]
    public class Message
    {
        [Key]
        [DataMember]
        public int MessageId { get; set; }
        [DataMember]
        public int SenderId { get; set; }
        [DataMember]
        public DateTime DateOfSend { get; set; }
        [DataMember]
        public DateTime TimeOfSend { get; set; }
        [DataMember]
        public string TextOfMessage { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        public ICollection<RecepientMessage> RecepientMessages { get; set; }

        public Message()
        {
            RecepientMessages = new List<RecepientMessage>();
        }
    }
}
