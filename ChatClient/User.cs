using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class User
    {
        public string Name { get; set; }
        public string Ip { get; set; }

        public User()
        {

        }

        public User(string name, string ip)
        {
            Name = name;
            Ip = ip;
        }
    }
}
