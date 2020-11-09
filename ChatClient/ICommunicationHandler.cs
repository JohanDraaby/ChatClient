using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;

namespace ChatClient
{
    interface ICommunicationHandler
    {
        void Send(string s);
        void Reciver();
        void Listen();
    }
}
