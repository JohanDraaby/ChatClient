using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace ChatClient
{
    class ChatController
    {
        private string reciveIp;
        private string senderIp;
        private string senderName;
        private byte messageType;
        private ICommunicationHandler commHandler;

     
        public string ReciveIp { get => reciveIp; set => reciveIp = value; }
        public string SenderIp { get => senderIp; set => senderIp = value; }
        public string SenderName { get => senderName; set => senderName = value; }

        // Types
        // 1 = string message
        // 2 = xml Message
        // 3 = sym Message
        // 4 = asym Message
        public byte MessageType { get => messageType; set => messageType = value; }
        public ICommunicationHandler CommHandler { get => commHandler; set => commHandler = value; }





        public ChatController(string reciveIp, string senderIp, byte messageType, ICommunicationHandler commHandler, string senderName)
        {
            ReciveIp = reciveIp;
            SenderIp = senderIp;
            MessageType = messageType;
            CommHandler = commHandler;
            SenderName = senderName;
        }

        public void Update(string name, string text)
        {

        }

        public void Connect()
        {
            if (commHandler is IConnect)
            {
                IConnect Handler = (IConnect)commHandler;
                Handler.Connect();
            }
        }

        public void SendMessage(string message)
        {
            //Update(SenderName, message);
            //MessageFactory.CreateMessage(message, 1);
            commHandler.Send(message);
        }


        public void GetKey()
        {

        }


    }
}
