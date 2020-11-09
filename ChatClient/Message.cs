using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClient
{
    class Message
    {
        private string receiverIP;
        private string senderIP;
        private string uMessage;
        public string ReceiverIP { get => receiverIP; set => receiverIP = value; }
        public string SenderIP { get => senderIP; set => senderIP = value; }
        public string MessageString { get => uMessage; set => uMessage = value; }

        public Message(string message)
        {
            ReceiverIP = receiverIP;
            SenderIP = senderIP;
            MessageString = message;
        }
    }
}
