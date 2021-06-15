using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRChatServerExample.InMemoryData;
using SignalRChatServerExample.Interfaces;
using SignalRChatServerExample.Models;

namespace SignalRChatServerExample.Hubs
{
    public class ChatHub : Hub<IChatStronglyTypedHub>
    {
        /// <summary>
        /// Login olan client-in nickName-nin diger userlerde gorunmesinin temin edilmesi
        /// </summary>
        /// <param name="nickName"></param>
        /// <returns></returns>
        public async Task GetNickNameAsync(string nickName)
        {
            InMemoryDB.Add(new Client
            {
                ConnectionId = Context.ConnectionId,
                NickName = nickName
            });

           
            // Join olan client istisna olmaqla digerlerine Join olanin NickName-nin gosterilmesi
            await Clients.Others.ClientJoinedAsync(nickName);

            // Butun clientlara cari client datalarinin gonderilmesi
            await Clients.All.SendClientsDataAsync(InMemoryDB.GetAll());
        }
    }
}
