using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string SenderPhone { get; set; }
        public string RecepientPhone { get; set; }
        public DateTime DateOfSend { get; set; }
        public DateTime TimeOfSend { get; set; }
        public string TextOfMessage { get; set; }

        [ForeignKey("SenderPhone")]
        public User Sender { get; set; }
        [ForeignKey("RecepientPhone")]
        public Recepient Recepient { get; set; }
    }
}
