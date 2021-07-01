using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatServerExample.Models
{
    public class Group
    {
        public Group()
        {
            Clients = new List<Client>();
        }
        public string Name { get; set; }

        public List<Client> Clients { get; set; }
    }
}
