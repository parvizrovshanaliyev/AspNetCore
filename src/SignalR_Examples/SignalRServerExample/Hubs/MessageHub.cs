using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
        Task ReceiveMessage(string message);
        Task GetConnectionId(string clientId);
    }
    public class MessageHub : Hub<IChatClient>
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

        #region Hub clients methods

        #region AllExcept
        /*
         * Bildirilen / nezerde tutulan clientlar istisna olmaqla server-a bagli
         * butun client-larla elaqe qurur.
         */
        public Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        {
            return Clients.AllExcept(connectionIds).ReceiveMessage(message);
        }

        #endregion
        #region Client
        /*
         * Bildirilen / nezerde tutulan client-la elaqe qurur.
         */
        //public Task SendMessageAsync(IEnumerable<string> connectionIds, string message)
        //{
        //    return Clients.Client(connectionIds.First()).ReceiveMessage(message);
        //}


        #endregion
        #region Clients
        /*
         * Bildirilen / nezerde tutulan client-larla elaqe qurur.
         */




        #endregion
        #region Group
        /*
         * Group-a subscribe olan butun clientlarla elaqe qurur yeni qrup daxili,
         * oncelikle mueyyen qruplar yaradilmalidir sonra client-lar o qruplara subscribe olmalidir.
         */


        /*
        * Ilk once istifadecinin secdiyi group hub yonlendirilir varsa hemin groupa subscribe
        * olur yoxdursa hemin group yaradilir subscribe olur
        */
        public async Task AddGroup(string connectionID, string groupName)
        {
            await Groups.AddToGroupAsync(connectionID, groupName);
        }

        /*
         * Client bu method-a muraciet ederek join oldugu qrupa mesaj gonderir
         */
        public Task SendMessageToGroupAsync(string groupName, string message)
        {
            /*
             * server to client hub-dan client-a mesaj gonderir.
             */
            return Clients.Groups(groupName).ReceiveMessage(message);
        }
        #endregion

        #region GroupExcept
        /*
         * Group daxilinde qeyd olunan clientlar istisna olmaqla diger clientlarla elaqe yaradilir.
         */
        

        #endregion
        #region OthersInGroup
        /*
         *
         */

        #endregion
        #region User
        /*
         *
         */


        #endregion
        #region Users
        /*
         *
         */


        #endregion
        #region MyRegion



        #endregion
        #region MyRegion



        #endregion
        #region MyRegion



        #endregion
        #region MyRegion



        #endregion
        #endregion

        #region Overrides of Hub

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.GetConnectionId(Context.ConnectionId);
        }

        #endregion
    }
}
