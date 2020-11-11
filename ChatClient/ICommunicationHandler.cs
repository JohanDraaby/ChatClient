using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;

namespace ChatClient
{
    interface ICommunicationHandler
    {
        void Send(byte[] msg/*string senderName, string senderIp, string reciverName, string reciverIp, string message*/);
        void Reciver();
        void Listen();
    }
}
