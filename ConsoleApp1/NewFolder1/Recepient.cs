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
    class Recepient
    {
        [Key]
        public int RecepientId { get; set; }
        public int RecepientMessagesId { get; set; }
        private string recepientPhone;
        public string RecepientPhone
        {
            get
            {
                return recepientPhone;
            }
            set
            {
                Regex phoneRegex = new Regex(@"^\+[0-9]{12}");
                if (phoneRegex.IsMatch(value))
                {
                    recepientPhone = value;
                }
                else
                {
                    Console.WriteLine("Invalid phone number");
                }
            }
        }
        public string FullName { get; set; }

        public ICollection<RecepientMessage> RecepientMessages { get; set; }

    }
}
