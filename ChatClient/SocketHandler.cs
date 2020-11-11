using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatClient
{
    class SocketHandler : IConnect, ICommunicationHandler, IDisconnect
    {

        TcpClient tcpClient = new TcpClient();
        Socket socket;

        public SocketHandler()
        {
            socket = tcpClient.Client;
        }

        // Connects to server
        public void Connect()
        {
            while (!tcpClient.Connected)
            {
                try
                {
                    // Server ip - 172.16.2.30
                    // Port cam - 8888 and 8889
                    // Port imo - 50001 - 50002
                    socket.Connect(IPAddress.Parse("172.16.2.30"), 8888); // Make dynamic port change
                }
                catch (Exception xt)
                {
                    Console.WriteLine(xt);
                }
            }

        }

        public void Disconnect()
        {
            socket.Close();
        }

        // dont think i need this
        public void Listen()
        {
            throw new NotImplementedException();
        }

        // recive a stream from the server
        public void Reciver()
        {
            while (tcpClient.Connected)
            {
                try
                {
                    byte[] bufferReciver = new byte[1024];

                    tcpClient.GetStream().Read(bufferReciver, 0, tcpClient.Available);
                    Console.WriteLine(Encoding.UTF8.GetString(bufferReciver));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        // using socket to send a byte[]
        public void Send(byte[] msg/*string senderName, string senderIp, string reciverName, string reciverIp, string message*/)
        {
            //string compMessage = senderName + ":" + senderName + ":" + senderIp + ":" + reciverName + ":" + reciverIp + ":" + message + "{END}";

            //string camstr = senderName + ":" + senderIp + ":" + reciverName + ":" + reciverIp + ":" + message + "\r\n";


            //byte[] byteBuffer = Encoding.UTF8.GetBytes(compMessage);
            try
            {
                socket.Send(msg);
                Console.WriteLine(Encoding.UTF8.GetString(msg));
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
