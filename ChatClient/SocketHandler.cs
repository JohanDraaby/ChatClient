using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatClient
{
    class SocketHandler : IConnect, ICommunicationHandler
    {

        TcpClient tcpClient = new TcpClient();
        Socket socket;

        public SocketHandler()
        {
            socket = tcpClient.Client;
        }

        public void Connect()
        {
            while (!tcpClient.Connected)
            {
                try
                {
                    socket.Connect(IPAddress.Parse("172.16.2.30"), 8888);
                }
                catch (Exception XT)
                {
                    Console.WriteLine(XT);
                }
            }

            //GetMsg();
        }

        public void Listen()
        {
            throw new NotImplementedException();
        }

        public void Reciver()
        {
            throw new NotImplementedException();
        }

        public void Send(string message)
        {
            string str = "JOLLE:172.16.2.40:Camilla:172.16.2.30:" + message + "\r\n";

            byte[] byteBuffer = Encoding.UTF8.GetBytes(str);
            byte[] bufferReciver = new byte[1024];
            bool check = false;
            while (tcpClient.Connected)
            {
                try
                {
                    if (!tcpClient.GetStream().DataAvailable && !check)
                    {
                        socket.Send(byteBuffer);
                        Console.WriteLine("I Have Send");
                        Thread.Sleep(3000);
                        check = true;
                    }
                    else
                    {
                        tcpClient.GetStream().Read(bufferReciver, 0, tcpClient.Available);
                        Console.WriteLine(Encoding.UTF8.GetString(bufferReciver));
                        check = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        //void GetMsg()
        //{
        //    using (TcpClient tcp = new TcpClient())
        //    {
        //        tcp.Connect(IPAddress.Parse("172.16.2.30"), 8888);
        //        string newip = "";
        //        byte[] buffer = new byte[1024];
        //        byte[] bufferRecive = new byte[1024];


        //        Console.WriteLine("Concetec to server");
        //        Socket s = tcp.Client;
        //        bool sendtData = false;
        //        while (tcp.Connected)
        //        {




        //            if (tcp.GetStream().DataAvailable)
        //            {
        //                string msg = Encoding.UTF8.GetString(buffer, 0, tcp.GetStream().Read(buffer, 0, tcp.Available));
        //                Console.WriteLine(msg);
        //                if (msg != "")
        //                {
        //                    string[] t = msg.Split(':');
        //                    newip = (t[t.Length - 1].Trim('\r').Trim('\n').Length == 11) ? newip : t[t.Length - 1].Trim('\r').Trim('\n');

        //                }
        //                Console.WriteLine("About to write to this ip : " + newip);
        //                Thread.Sleep(1000);
        //                //newip = "172.16.2.44";
        //                sendtData = true;



        //            }
        //            if (!tcp.GetStream().DataAvailable && tcp.Available <= 0 && sendtData)
        //            {
        //                string msgs = $"Andi:172.16.2.36:Jolle:{newip}:Hej Krøl:Hej HighTower";
        //                newip = "";
        //                bufferRecive = Encoding.UTF8.GetBytes(msgs);
        //                s.Send(bufferRecive);
        //                Console.WriteLine(newip);



        //                Console.WriteLine(s.Send(bufferRecive) + " Sendt");
        //                sendtData = true;
        //                Thread.Sleep(1000);
        //            }
        //        }
        //    }
        //}
    }
}
