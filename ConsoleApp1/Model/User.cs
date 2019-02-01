using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;
using ConsoleApp1.NewFolder1;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserPhone { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public ICollection<Message> Messages { get; set; }

        public User()
        {
            Messages = new List<Message>();
        }
    }
}
