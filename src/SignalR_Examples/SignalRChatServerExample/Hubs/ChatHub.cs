using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRChatServerExample.InMemoryData;
using SignalRChatServerExample.Interfaces;
using SignalRChatServerExample.Models;

namespace SignalRChatServerExample.Hubs
{
    public class ChatHub : Hub<IChatStronglyTypedHub>
    {
        #region fields

        private const string All = "All";
        private const string GroupName = "-1";


        #endregion
        /// <summary>
        /// Login olan client-in nickName-nin diger userlerde gorunmesinin temin edilmesi
        /// </summary>
        /// <param name="nickName"></param>
        /// <returns></returns>
        public async Task GetNickNameAsync(string nickName)
        {
            InMemoryDB.AddClient(new Client
            {
                ConnectionId = Context.ConnectionId,
                NickName = nickName
            });


            // Join olan client istisna olmaqla digerlerine Join olanin NickName-nin gosterilmesi
            await Clients.Others.ClientJoinedAsync(nickName);

            // Butun clientlara cari client datalarinin gonderilmesi
            await Clients.All.ClientsDataAsync(InMemoryDB.GetAllClient());
        }

        /// <summary>
        /// Clientlar arasinda mesajlasma
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageAsync(string message, string nickName)
        {
            nickName = nickName.Trim();

            var senderClient = InMemoryDB.GetClientByConnectionId(Context.ConnectionId);

            if (nickName == All)
            {
                await Clients.Others.ReceiveMessageAsync(senderClient.NickName, message);
            }
            else
            {
                var receiverClient = InMemoryDB.GetClientByNickName(nickName);
                await Clients.Client(receiverClient.ConnectionId).ReceiveMessageAsync(senderClient.NickName, message);
            }

        }
        public async Task SendMessageToGroupAsync(string message, string groupName)
        {
            groupName = groupName.Trim();

            var senderClient = InMemoryDB.GetClientByConnectionId(Context.ConnectionId);

            await Clients.Groups(groupName).ReceiveMessageAsync(senderClient.NickName, message);

        }
        public async Task AddGroupAsync(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            InMemoryDB.AddGroup(groupName, Context.ConnectionId);

            await Clients.All.GroupsAsync(InMemoryDB.GetAllGroups());
        }


        public async Task AddClientToGroupsAsync(IEnumerable<string> groupNames)
        {
            Client client = InMemoryDB.GetClientByConnectionId(Context.ConnectionId);

            foreach (var groupName in groupNames)
            {
                Group group = InMemoryDB.GetGroup(groupName);

                var result = group.Clients.Any(i => i.ConnectionId == Context.ConnectionId);
                if (result) continue;
                @group.Clients.Add(client);

                await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            }
        }

        public async Task GetClientsToGroupAsync(string groupName)
        {
            Group group = InMemoryDB.GetGroup(groupName);
            
            await Clients.Caller.ClientsDataAsync(
                groupName == GroupName
                    ? InMemoryDB.GetAllClient()
                    : group.Clients);
        }
    }
}
