using System.Collections.Generic;
using System.Linq;
using SignalRChatServerExample.Models;

namespace SignalRChatServerExample.InMemoryData
{
    public static class InMemoryDB
    {
        private static readonly List<Client> _clients;


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
            if (GetClientByNickName(client.NickName) is null)
            {
                _clients.Add(client);
            }
        }


        public static Client GetClientByNickName(string nickName)
        {
            return _clients.SingleOrDefault(i => i.NickName == nickName);
        }

        public static Client GetClientByConnectionId(string connectionId)
        {
            return _clients.SingleOrDefault(i => i.ConnectionId == connectionId);
        }
    }
}