using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            using (MessagesSendingDbContext db = new MessagesSendingDbContext())
            {
                db.SaveChanges();
                WriteLine("Input phone number:");
                string phoneNumber = ReadLine();
                Regex phoneRegex = new Regex(@"^\+[0-9]{12}");
                if (!phoneRegex.IsMatch(phoneNumber))
                {
                    WriteLine("Invalid phone number");
                    return;
                }
                User user = db.Users.FirstOrDefault(p => p.UserPhone == phoneNumber);
                string answer;
                if (user == null)
                {
                    WriteLine("Cant find user");
                    WriteLine("Want to regitrate(Yes/No)");
                    answer = ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        db.Users.Add(UserRegistration());
                        db.SaveChanges();
                        string[] vs = new string[1];
                        Main(vs);
                        return;
                    }
                    else
                    {
                        WriteLine("Thanks for visit");
                        return;
                    }
                }
                WriteLine("Input password: ");
                if (user.Password == ReadLine())
                {
                    WriteLine("Log in");
                }
                else
                {
                    WriteLine("Wrong password!");
                    WriteLine("Thanks for visit");
                    return;
                }
                WriteLine("Want you see your messages?(Yes/No): ");
                answer = ReadLine().ToLower();
                if (answer == "yes")
                {
                    var messages = db.Messages.Where(p => p.SenderId == user.UserId);
                    foreach (Message message in messages)
                    {
                        WriteLine("Text of message: {0}", message.TextOfMessage);
                        WriteLine("Recipients:");
                        foreach (RecepientMessage recepientMessage in message.RecepientMessages)
                        {
                            Recepient recepient = db.Recepients.Find(recepientMessage.RecepientId);
                            WriteLine("Recepient's name: {0}  phone number: {1} ", recepient.FullName, recepient.RecepientPhone);
                        }
                    }
                }
                WriteLine("Want you add new message?(Yes/No): ");
                answer = ReadLine().ToLower();
                if (answer == "yes")
                {
                    Message newMessage = new Message();
                    newMessage.Sender = user;
                    WriteLine("Input message's text:");
                    newMessage.TextOfMessage = ReadLine();
                    do
                    {
                        WriteLine("Input recipient's phone number: ");
                        phoneNumber = ReadLine();
                        if (!phoneRegex.IsMatch(phoneNumber))
                        {
                            WriteLine("Invalid phone number");
                            return;
                        }
                        Recepient recepient = db.Recepients.FirstOrDefault(p => p.RecepientPhone == phoneNumber);
                        if (user == null)
                        {
                            WriteLine("Cant find reciepient");
                            WriteLine("Want to regitrate(Yes/No)");
                            answer = ReadLine().ToLower();
                            if (answer == "yes")
                            {
                                Recepient newRecepient = RecepientRegistration();
                                db.Recepients.Add(newRecepient);

                            }
                            else
                            {
                                WriteLine("Thanks for visit");
                                return;
                            }
                        }
                    }
                    while ();
                }
            }

        }

        static User UserRegistration()
        {
            User newUser = new User();
            WriteLine("Input phone number: ");
            newUser.UserPhone = ReadLine();
            WriteLine("Input password: ");
            newUser.Password = ReadLine();
            WriteLine("Input full name: ");
            newUser.FullName = ReadLine();
            return newUser;
        }

        static Recepient RecepientRegistration()
        {
            Recepient newRecepient = new Recepient();
            WriteLine("Input phone number: ");
            newRecepient.RecepientPhone = ReadLine();
            WriteLine("Input full name: ");
            newRecepient.FullName = ReadLine();
            return newRecepient;
        }
    }
}
