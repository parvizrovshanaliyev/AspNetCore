using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
    }
    public class MessageHub:Hub<IChatClient>
    {
        #region all
        /*
         * server-a bagli olan butun client-larla elaqe qurar.
         */
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.ReceiveMessage(user, message);
        }
        #endregion
        #region caller
        /*
         * sadece server-a bildiris gonderen client-la elaqe qurur.
         */
        public Task SendMessageToCaller(string user, string message)
        {
            return Clients.Caller.ReceiveMessage(user, message);
        }
        #endregion

        #region others
        /*
         * sadece server`a bildiris gonderen client istisna server-a bagli diger
         * butun client-larla elaqe qurur.
         */

        public Task SendMessageToOthers(string user, string message)
        {
            return Clients.Others.ReceiveMessage(user, message);
        }
        #endregion
    }
}
