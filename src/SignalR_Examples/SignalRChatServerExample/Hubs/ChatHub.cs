using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRChatServerExample.InMemoryData;
using SignalRChatServerExample.Interfaces;
using SignalRChatServerExample.Models;

namespace SignalRChatServerExample.Hubs
{
    public class ChatHub : Hub<IChatStronglyTypedHub>
    {
        public async Task GetNickName(string nickName)
        {
            Client client = new Client
            {
                ConnectionId = Context.ConnectionId,
                NickName = nickName
            };
            InMemoryDB.Clients.Add(client);

            /*
             * Join olan client-dan basqa butun joine olanlarin nickNamenin gosterilmesi
             *
             */

            await Clients.Others.ClientJoined(nickName);
        }
    }
}
