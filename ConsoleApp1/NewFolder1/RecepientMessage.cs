using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class RecepientMessage
    {
        [Key]
        public int RecepientMessageId { get; set; }
        public int RecepientId { get; set; }
        public int MessageId { get; set; }

        [ForeignKey("RecepientId")]
        public Recepient Recepient { get; set; }
        [ForeignKey("MessageId")]
        public Message Message { get; set; }
    }
}
