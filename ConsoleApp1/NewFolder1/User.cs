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
    [Serializable]
    [DataContract]
    class User
    {
        [Key]
        [DataMember]
        public int UserId { get; set; }
        private string userPhone;
        [DataMember]
        public string UserPhone
        {
            get
            {
                return userPhone;
            }
            set
            {
                Regex phoneRegex = new Regex(@"^\+[0-9]{12}");
                if (phoneRegex.IsMatch(value))
                {
                    userPhone = value;
                }
                else
                {
                    Console.WriteLine("Invalid phone number");
                }
            }
        }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FullName { get; set; }

        public ICollection<Message> Messages { get; set; }

        public User()
        {
            Messages = new List<Message>();
        }

        public User(string userPhone, string password, string fullName, string address)
        {
            UserPhone = userPhone;
            Password = password;
            FullName = fullName;
        }

    }
}
