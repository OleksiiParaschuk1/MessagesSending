using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    class Recepient
    {
        [Key]
        public string RecepientId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public ICollection<Message> Messages { get; set; }

        public Recepient()
        {
            Messages = new List<Message>();
        }
    }
}
