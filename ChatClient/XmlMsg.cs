using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ChatClient
{
    class XmlMsg : Message
    {
        private byte[] messageBuffer;
        public byte[] MessageBuffer { get; set; }

        public XmlMsg(User to, User from, MessageBody mb, byte[] messageBuffer):base(to, from, mb)
        {
            MessageBuffer = messageBuffer;
        }
    }
}
