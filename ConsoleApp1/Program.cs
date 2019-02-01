using ConsoleApp1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static UserRepository userRepository;
        static MessageRepository messageRepository;
        static RecepientMessageRepository recepientMessageRepository;
        static RecepientRepository recepientRepository;
        static User user;
        static string phoneNumber;
        static Regex phoneRegex;
        static string answer;

        static void Main(string[] args)
        {
            using (MessagesSendingDbContext db = new MessagesSendingDbContext())
            {
                userRepository = new UserRepository(db);
                messageRepository = new MessageRepository(db);
                recepientMessageRepository = new RecepientMessageRepository(db);
                recepientRepository = new RecepientRepository(db);
               
                phoneRegex = new Regex(@"^\+[0-9]{12}");
                user = new User();
                EnterMenu();
            }
        }

        static void EnterMenu()
        {
            int resOfChoose = UserInterface("Log in", "Registrate", "Exit");
            switch (resOfChoose)
            {
                case 0:
                    WriteLine("Input phone number:");
                    phoneNumber = ReadLine();
                    if (!phoneRegex.IsMatch(phoneNumber))
                    {
                        WriteLine("Invalid phone number");
                    }
                    WriteLine("Input password: ");
                    string password = ReadLine();
                    user = userRepository.GetByPhoneNumber(phoneNumber);
                    if (user == null)
                    {
                        WriteLine("Wrong Phone number or password");
                        EnterMenu();
                    }
                    if (user.Password == password)
                    {
                        WriteLine("Log in");
                    }
                    MessegesRecipientsMenu();
                    break;
                case 1:
                    userRepository.Create(UserRegistration());
                    userRepository.SaveChanges();
                    EnterMenu();
                    return;
                case 2:
                    return;
                default:
                    WriteLine("Thanks for visit");
                    return;
            }
        }

        static void MessegesRecipientsMenu()
        {
            int resOfChoose = UserInterface("View messages", "Add message", "View your recipeints", "Add new recipient", "Exit");
            switch (resOfChoose)
            {
                case 0:
                    var messages = messageRepository.GetMessagesBySenderId(user.UserId);
                    foreach (Message message in messages)
                    {
                        WriteLine("Text of message: {0}", message.TextOfMessage);
                        var messagesResipients = recepientMessageRepository.GetRecepientsMessagesByMessageId(message.MessageId);
                        WriteLine("Recipients:");
                        foreach (RecepientMessage recepientMessage in messagesResipients)
                        {
                            Recepient recepient = recepientRepository.GetById(recepientMessage.RecepientId);
                            WriteLine("Recepient's name: {0}  phone number: {1} ", recepient.FullName, recepient.RecepientPhone);
                        }
                    }
                    WriteLine("Press any key to return");
                    ReadKey();
                    MessegesRecipientsMenu();
                    return;
                case 1:
                    Message newMessage = new Message();
                    newMessage.Sender = user;
                    WriteLine("Input message's text:");
                    newMessage.TextOfMessage = ReadLine();
                    newMessage.DateOfSend = DateTime.Now;
                    newMessage.TimeOfSend = DateTime.Now;
                    messageRepository.Create(newMessage);
                    messageRepository.SaveChanges();
                    messageRepository.SetInFileJson(newMessage);
                    bool stop = false;
                    do
                    {
                        WriteLine("Input recipient's phone number: ");
                        phoneNumber = ReadLine();
                        if (!phoneRegex.IsMatch(phoneNumber))
                        {
                            WriteLine("Invalid phone number");
                            return;
                        }
                        Recepient recepient = recepientRepository.GetByPhoneNumber(phoneNumber);
                        if (recepient == null)
                        {
                            WriteLine("Cant find reciepient");
                            WriteLine("Want to regitrate(Yes/No)");
                            answer = ReadLine().ToLower();
                            if (answer == "yes")
                            {
                                Recepient newRecepient = RecepientRegistration();
                                recepientRepository.Create(newRecepient);
                                recepientRepository.SaveChanges();
                                RecepientMessage newRecepientMessage = new RecepientMessage();
                                newRecepientMessage.Recepient = newRecepient;
                                newRecepientMessage.Message = newMessage;
                                recepientMessageRepository.Create(newRecepientMessage);
                                recepientMessageRepository.SaveChanges();
                            }
                            else
                            {
                                WriteLine("Thanks for visit");
                                return;
                            }
                        }
                        else
                        {
                            RecepientMessage newRecepientMessage = new RecepientMessage();
                            newRecepientMessage.Recepient = recepient;
                            newRecepientMessage.Message = newMessage;
                            recepientMessageRepository.Create(newRecepientMessage);
                            recepientMessageRepository.SaveChanges();
                        }
                        WriteLine("Want you add other recepient?(Yes/No): ");
                        answer = ReadLine().ToLower();
                        if (answer == "yes") { stop = false; }
                        else { stop = true; }
                    }
                    while (!stop);
                    WriteLine("Press any key to return");
                    ReadKey();
                    MessegesRecipientsMenu();
                    return;
                case 2:
                    var messages1 = messageRepository.GetMessagesBySenderId(user.UserId);
                    WriteLine("Recipients:");
                    foreach (Message message in messages1)
                    {
                        var messagesResipients = recepientMessageRepository.GetRecepientsMessagesByMessageId(message.MessageId);
                        foreach (RecepientMessage recepientMessage in messagesResipients)
                        {
                            Recepient recepient = recepientRepository.GetById(recepientMessage.RecepientId);
                            WriteLine("Recepient's name: {0}  phone number: {1} ", recepient.FullName, recepient.RecepientPhone);
                        }
                    }
                    WriteLine("Press any key to return");
                    ReadKey();
                    MessegesRecipientsMenu();
                    return;
                case 3:
                    Recepient newRecepient1 = RecepientRegistration();
                    recepientRepository.Create(newRecepient1);
                    recepientRepository.SaveChanges();
                    WriteLine("Press any key to return");
                    ReadKey();
                    MessegesRecipientsMenu();
                    return;
                case 4:
                    return;
                default:
                    WriteLine("Thanks for visit");
                    return;
            }
        }

        static int UserInterface(params string[] menuItems)
        {
            short curItem = 0, c;
            ConsoleKeyInfo key;

            do
            {
                Clear();
                WriteLine("Select an option . . .");
                for (c = 0; c < menuItems.Length; c++)
                {
                    if (curItem == c)
                    {
                        Write(">>");
                        WriteLine(menuItems[c]);
                    }
                    else
                    {
                        WriteLine(menuItems[c]);
                    }
                }

                key = ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                }
            } while (key.KeyChar != 13);

            Clear();

            return curItem;
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
