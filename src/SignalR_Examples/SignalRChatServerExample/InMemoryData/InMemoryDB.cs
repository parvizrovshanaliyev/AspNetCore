using System.Collections.Generic;
using System.Linq;
using SignalRChatServerExample.Models;

namespace SignalRChatServerExample.InMemoryData
{
    public static class InMemoryDB
    {
        private static readonly List<Client> _clients;
        private static readonly List<Group> _groups;


        static InMemoryDB()
        {
            _clients = new List<Client>();
            _groups = new List<Group>();
        }

        public static List<Client> GetAllClient()
        {
            return _clients;
        }

        public static void AddClient(Client client)
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

        public static void AddGroup(string groupName,string connectionId)
        {
            if (GetGroup(groupName) is not null) return;
            var group = new Group
            {
                Name = groupName
            };

            // added Client to Group
            @group.Clients.Add(GetClientByConnectionId(connectionId));
                
            _groups.Add(@group);
        }
        public static Group GetGroup(string groupName)
        {
            return _groups.SingleOrDefault(i => i.Name == groupName);
        }
        public static List<Group> GetAllGroups()
        {
            return _groups;
        }
    }
}