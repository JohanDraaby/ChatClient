using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClient
{
    public class PlainTextMsg : Message
    {

        private byte[] messageBuffer;
        public byte[] MessageBuffer { get; set; }

        public PlainTextMsg(User from, User to, MessageBody mb) :base(from, to, mb)
        {
            // MessageBuffer = Encoding.ASCII.GetBytes(From.Name + ":" + From.Name + ":" + From.Ip + ":" + To.Name + ":" + To.Ip + ":" + Mb.Body + "{END}");
            MessageBuffer = Encoding.ASCII.GetBytes(From.Name + ":" + From.Name + ":" + From.Ip + ":" + To.Name + ":" + To.Ip + ":" + Mb.Body + "\r\n");
        }
    }
}
