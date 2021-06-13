using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Interfaces;

namespace SignalRServerExample.Hubs
{
   
    /*
     * 1.appde oncelikle sonunda HUB deye adlandirilan class
     * yaradilir ve HUB classindan inheritance alir bununla
     * TCP protokolundan istifade edeceyik.
     */


    public class MyHub: Hub<IMessageClient> // v1-Hub sadece Hubdan inheritance alinir
    {


        #region fields

        private static readonly List<string> clientsDataList = new List<string>();

        private readonly IHubContext<MyHub> _hubContext;

        public MyHub(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }
        #endregion
        /// <summary>
        /// 2.message parametri qebul eden bu method icerisinde Hub-dan gelen
        /// Clients prop vasitesile .All butun istifadecilerde "receiveMessage"
        /// methodunu ise salib qebul olunan message param-i olara gonderirik
        ///
        /// 3. Goto StartUp class
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageAsync(string message)
        {
            //await _hubContext.Clients.All.SendAsync("receiveMessage", message);

            // strongly Typed
            await base.Clients.All.ReceiveMessage( message);
           
        }


        /*
         * Context.ConnectinId Hub -a qosulan clientlari bir birinden ayirmaq ucun istifade
         * edilen sistem terefinden verilmis unique id-dir.
         */
        #region Overrides of Hub

        /// <summary>
        /// Baglanti zamani ise dusecek
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            //What are Connection Events? How to List All Clients?
            clientsDataList.Add(Context.ConnectionId);
            /*
             * v1
             */
            //await base.Clients.All.SendAsync("clients", Clients);
            //await base.Clients.All.SendAsync("userJoined", Context.ConnectionId);

            /*
             * v2 strongly typed hubs
             */
            await base.Clients.All.Clients(clientsDataList);
            await base.Clients.All.UserJoined(Context.ConnectionId);
        }

        /// <summary>
        /// Baglanti qopan zaman ise dusecek
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //What are Connection Events? How to List All Clients?
            clientsDataList.Remove(Context.ConnectionId);
            /*
             * v1
             */
            //await base.Clients.All.SendAsync("clients", Clients);
            //await base.Clients.All.SendAsync("userLeaved", Context.ConnectionId);
            /*
             * v2 strongly typed hubs
             */
            await base.Clients.All.Clients(clientsDataList);
            await base.Clients.All.UserLeaved(Context.ConnectionId);

        }
        
        #endregion
        
       
    }
}
