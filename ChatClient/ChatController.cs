using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace ChatClient
{
    class ChatController
    {
        private User sender;
        private User reciver;
        private byte messageType;
        private ICommunicationHandler commHandler;


        public User Sender { get => sender; set => sender = value; }
        public User Reciver { get => reciver; set => reciver = value; }

        // Types
        // 1 = string message
        // 2 = xml Message
        // 3 = sym Message
        // 4 = asym Message
        public byte MessageType { get => messageType; set => messageType = value; }
        public ICommunicationHandler CommHandler { get => commHandler; set => commHandler = value; }





        public ChatController(string reciveIp, string senderIp, byte messageType, ICommunicationHandler commHandler, string senderName, string reciverName)
        {
            sender = new User(senderName, senderIp);
            Reciver = new User(reciverName, reciveIp);

            MessageType = messageType;
            CommHandler = commHandler;

        }

        // Use for update ign chat
        public void Update()
        {
            commHandler.Reciver();
        }

        // Connects to server
        public void Connect()
        {
            if (commHandler is IConnect)
            {
                IConnect Handler = (IConnect)commHandler;
                Handler.Connect();
            }
        }
        public void Disconnect()
        {
            if (commHandler is IDisconnect)
            {
                IDisconnect Handler = (IDisconnect)commHandler;
                Handler.Disconnect();
            }
        }

        // Getting message from program/Main and creating message with messagefactory and passing it on to the socketHandler
        public void SendMessage(string message)
        {
            // creating message of messagetype
            Message msg = MessageFactory.CreateMessage(MessageType, Sender, Reciver, message);
            if (msg is XmlMsg)
            {
                XmlMsg xmlmsg = (XmlMsg)msg;
                commHandler.Send(xmlmsg.MessageBuffer);
            }
            else if(msg is PlainTextMsg)
            {
                PlainTextMsg plainMsg = (PlainTextMsg)msg;
                commHandler.Send(plainMsg.MessageBuffer);
            }
        }

        // Use for keys later
        public void GetKey()
        {

        }


    }
}
