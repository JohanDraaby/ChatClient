using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class MessageBody
    {
        public string Body { get; set; }

        public MessageBody()
        {

        }

        public MessageBody(string body)
        {
            Body = body;
        }
    }
}
