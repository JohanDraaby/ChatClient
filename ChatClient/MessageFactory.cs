using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ChatClient
{
    class MessageFactory
    {
        public static Message CreateMessage(byte messageType, User to, User from, string message)
        {
            if (messageType == 1)
            {
                // Creates a Message.
                 return new PlainTextMsg(to, from, new MessageBody(message));
            }
            else if (messageType == 2)
            {
                // Xml
                MessageBody mb = new MessageBody(message);
                Message msg = new Message(to, from, mb);

                return new XmlMsg(to, from, mb, SerializeElement(msg));
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

        public static byte[] SerializeElement(Message message)
        {
            XmlSerializer ser = new XmlSerializer(message.GetType());
            byte[] bufferStream = new byte[1024];
            MemoryStream s = new MemoryStream(bufferStream);
            ser.Serialize(s, message);
            return Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(bufferStream).Replace("\0","")); // Putting it in a string and removing all whitespace (\0) and converting it back to byte[]
        }
    }
}
