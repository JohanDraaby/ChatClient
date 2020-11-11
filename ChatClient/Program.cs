using System;
using System.Net;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Welcome ====");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1: - Connect");
                Console.WriteLine();
                Console.WriteLine("2: - Recive");
                Console.WriteLine();
                Console.WriteLine("3: - Config");
                Console.WriteLine();
                Console.WriteLine("4: - Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // 1: - Connect
                        bool isSocketOpen = true;
                        // Enter Username (The Name is not inportant)
                        Console.Write("Enter Username: ");
                        string userName = Console.ReadLine();

                        // Enter last 2 digits for reciver
                        Console.Write("Enter Final Receiver IP Digits: ");
                        string receiverIP = "172.16.2." + Console.ReadLine();

                        // Enter reciver name (The Name is not inportant)
                        Console.Write("Enter Receiver's Name: ");
                        string receiverName = Console.ReadLine();

                        // Enter Message Type
                        Console.Write("Enter Message Type: ");
                        byte messageType = Convert.ToByte(Console.ReadLine());

                        ChatController chatController = new ChatController(receiverIP, "172.16.2.45"/*Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString()*/,
                            messageType, new SocketHandler(), userName, receiverName);

                        chatController.Connect();

                        while (isSocketOpen)
                        {
                            Console.Clear();
                            Console.WriteLine("Use 'Exit' to go back");
                            Console.WriteLine("Enter A Message");
                            string userMessage = Console.ReadLine();
                            if (userMessage == "Exit")
                            {
                                isSocketOpen = false;
                                chatController.Disconnect();
                            }
                            else
                            {
                                chatController.SendMessage(userMessage);
                            }
                        }
                        break;

                    case "2":
                        // Recive
                        ChatController chatControllerRecive = new ChatController("172.16.2.30", Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(),
                            1, new SocketHandler(), "Jolle", "Server");

                        chatControllerRecive.Connect();
                        Console.Clear();
                        Console.WriteLine("==== Chat ====");
                        chatControllerRecive.Update();
                        break;

                    case "3":
                        // Config
                        break;
                    case "4":
                        // Exit
                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
}
