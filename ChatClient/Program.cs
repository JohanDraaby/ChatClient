using System;
using System.Net;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Clear();
            Console.WriteLine("==== Welcome ====");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1: - Connect");
            Console.WriteLine();
            Console.WriteLine("2: - Config");
            Console.WriteLine();
            Console.WriteLine("3: - Exit");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    // Connect
                    Console.Clear();
                    Console.WriteLine("Enter Sender Name:");
                    string userNameInput = Console.ReadLine();
                    ChatController chatController = new ChatController("Reciver Ip", Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(), 1, new SocketHandler(), userNameInput);
                    chatController.Connect();

                    while (true)
                    {

                    Console.WriteLine();
                    Console.WriteLine("Enter Message:");
                    string userMessageInput = Console.ReadLine();
                    chatController.SendMessage(userMessageInput);

                    }
                    break;

                case "2":
                    // Config
                    break;

                case "3":
                    // Exit
                    Environment.Exit(1);
                    break;
            }




            Console.ReadKey();

        }
    }
}
