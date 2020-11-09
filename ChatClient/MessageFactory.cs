using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClient
{
    class MessageFactory
    {



        public static Message CreateMessage(string messageText, byte messageType)
        {
            if (messageType == 1)
            {
                // Creates a Message.
                return new Message(messageText);
            }
            else if (messageType == 2)
            {
                // Xml
                return null;
            }
            else if (messageType == 3)
            {
                // Symm
                return null;
            }
            else
            {
                // Asymm
                return null;
            }
        }
    }
}
