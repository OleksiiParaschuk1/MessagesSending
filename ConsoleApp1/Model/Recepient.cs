using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Recepient
    {
        [Key]
        public int RecepientId { get; set; }
        public string RecepientPhone { get; set; }
        public string FullName { get; set; }

        public ICollection<RecepientMessage> RecepientMessages { get; set; }

        public Recepient()
        {
            RecepientMessages = new List<RecepientMessage>();
        }
    }
}
