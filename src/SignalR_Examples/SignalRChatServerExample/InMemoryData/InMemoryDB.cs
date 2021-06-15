using System.Collections.Generic;
using SignalRChatServerExample.Models;

namespace SignalRChatServerExample.InMemoryData
{
    public static class InMemoryDB
    {
        private static readonly List<Client>  _clients;


        static InMemoryDB()
        {
            _clients = new List<Client>();
        }

        public static List<Client> GetAll()
        {
            return _clients;
        }

        public static void Add(Client client)
        {
            _clients.Add(client);
        }
    }
}